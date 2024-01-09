using ECommerce.Application.Contracts.Email;
using ECommerce.Application.Contracts.Identity;
using ECommerce.Application.Contracts.Logging;
using ECommerce.Application.Exceptions;
using ECommerce.Application.Models.Identity;
using ECommerce.Identity.Models;
using ECommerce.Identity.Notifications.Emails;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Web;

namespace ECommerce.Identity.Services
{
    public class AuthService : IAuthService
    {
        private const string refreshToken = "RefreshToken";

        private readonly IConfiguration _configuration;
        private readonly UserManager<AppUser> _userManager;
        private readonly JwtSettings _jwtSettings;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IAppLogger<AuthService> _logger;
        private readonly IEmailSender _emailSender;

        public AuthService(
            IConfiguration configuration,
            UserManager<AppUser> userManager,
            IOptions<JwtSettings> jwtSettings,
            SignInManager<AppUser> signInManager,
            IAppLogger<AuthService> logger,
            IEmailSender emailSender)
        {
            _configuration = configuration;
            _userManager = userManager;
            _jwtSettings = jwtSettings.Value;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
        }

        public async Task<AuthResponse> Login(AuthRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user is null)
                throw new NotFoundException($"User", request.Email);

            var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

            if (!result.Succeeded)
                throw new UnauthorizedException($"Credentials for {request.Email} are not valid.");

            JwtSecurityToken jwtToken = await GenerateToken(user);
            var jwtRefreshToken = await GenerateRefreshToken(user);

            var response = new AuthResponse
            {
                Id = user.Id,
                Token = new JwtSecurityTokenHandler().WriteToken(jwtToken),
                RefreshToken = jwtRefreshToken,
                Email = user.Email!,
                Roles = (await _userManager.GetRolesAsync(user)).ToList(),
            };

            return response;
        }

        public async Task<AuthResponse> VerifyRefreshToken(AuthRefreshRequest request)
        {
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var tokenContent = jwtSecurityTokenHandler.ReadJwtToken(request.Token);
            var username = tokenContent.Claims.ToList().FirstOrDefault(q => q.Type == JwtRegisteredClaimNames.Email)?.Value;
            var user = await _userManager.FindByNameAsync(username);

            if (user == null)
            {
                throw new UnauthorizedException($"Credentials for {username} are not valid.");
            }

            var isValidRefreshToken = await _userManager.VerifyUserTokenAsync(user, _jwtSettings.Issuer, refreshToken, request.RefreshToken);

            if (isValidRefreshToken)
            {
                var token = await GenerateToken(user);
                return new AuthResponse
                {
                    Id = user.Id,
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    RefreshToken = await GenerateRefreshToken(user)
                };
            }

            await _userManager.UpdateSecurityStampAsync(user);
            return null;
        }

        public async Task<RegistrationResponse> Register(RegistrationRequest request)
        {
            var user = new AppUser
            {
                Email = request.Email,
                UserName = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                EmailConfirmed = false
            };

            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
            {
                StringBuilder str = new StringBuilder();
                foreach (var err in result.Errors)
                {
                    str.AppendFormat("{0}\n", err.Description);
                }
                throw new BadRequestException($"{str}");
            }

            await _userManager.AddToRoleAsync(user, "User");
            var token = HttpUtility.UrlEncode(await _userManager.GenerateEmailConfirmationTokenAsync(user));

            await _emailSender.SendEmailAsync(new EmailVerificationEmail(_configuration, user, token).PrepareEmail());

            return new RegistrationResponse() { Id = user.Id };

        }

        public async Task<ForgotPasswordResponse> ForgotPassword(ForgotPasswordRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
                throw new NotFoundException("User", request.Email);

            var token = HttpUtility.UrlEncode(await _userManager.GeneratePasswordResetTokenAsync(user));
            await _emailSender.SendEmailAsync(new ForgotPasswordEmail(_configuration, user, token).PrepareEmail());

            return new ForgotPasswordResponse { Succeeded = true };
        }

        public async Task<ResetPasswordResponse> ResetPassword(ResetPasswordRequest request)
        {
            var user = await _userManager.FindByIdAsync(request.UserId);
            if (user == null)
                throw new NotFoundException("User", request.UserId);

            var token = HttpUtility.UrlDecode(request.ResetToken);
            var result = await _userManager.ResetPasswordAsync(user, token, request.NewPassword);
            if (!result.Succeeded)
            {
                StringBuilder str = new StringBuilder();
                foreach (var err in result.Errors)
                {
                    str.AppendFormat("{0}\n", err.Description);
                }
                throw new BadRequestException($"{str}");
            }

            return new ResetPasswordResponse { Succeeded = result.Succeeded };
        }

        public async Task<EmailVerificationResponse> VerifyEmail(EmailVerificationRequest request)
        {
            var user = await _userManager.FindByIdAsync(request.Id);

            if (user is null)
                throw new NotFoundException($"User with not found.", request.Id);

            var token = HttpUtility.UrlDecode(request.VerificationCode);
            var result = await _userManager.ConfirmEmailAsync(user, token);

            if (!result.Succeeded)
            {
                StringBuilder str = new StringBuilder();
                foreach (var err in result.Errors)
                {
                    str.AppendFormat("{0}\n", err.Description);
                }
                throw new BadRequestException($"{str}");
            }

            return new EmailVerificationResponse { Succeeded = result.Succeeded };
        }

        private async Task<string> GenerateRefreshToken(AppUser user)
        {
            await _userManager.RemoveAuthenticationTokenAsync(user, _jwtSettings.Issuer, refreshToken);
            var newRefreshToken = await _userManager.GenerateUserTokenAsync(user, _jwtSettings.Issuer, refreshToken);
            var result = await _userManager.SetAuthenticationTokenAsync(user, _jwtSettings.Issuer, refreshToken, newRefreshToken);
            return newRefreshToken;
        }

        private async Task<JwtSecurityToken> GenerateToken(AppUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var userRoles = await _userManager.GetRolesAsync(user);
            var rolesClaims = userRoles.Select(r => new Claim(ClaimTypes.Role, r)).ToList();

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("uid", user.Id)
            }
            .Union(userClaims)
            .Union(rolesClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var jwtToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
                signingCredentials: signingCredentials);

            return jwtToken;
        }
    }
}
