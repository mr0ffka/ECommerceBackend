using ECommerce.Application.Contracts.Identity;
using ECommerce.Application.Models.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Api.Controllers
{
    [Route("api/auth/")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthResponse>> Login(AuthRequest request)
        {
            var response = await _authService.Login(request);

            return Ok(response);
        }

        [HttpPost("register")]
        public async Task<ActionResult<RegistrationResponse>> Register(RegistrationRequest request)
        {
            return Ok(await _authService.Register(request));
        }

        [HttpGet("verify-email")]
        public async Task<ActionResult<EmailVerificationResponse>> VerifyEmail([FromQuery] string id, [FromQuery] string token)
        {
            return Ok(await _authService.VerifyEmail(new EmailVerificationRequest { Id = id, VerificationCode = token}));
        }

        [HttpPost("forgot-password")]
        public async Task<ActionResult<ForgotPasswordResponse>> ForgotPassword(ForgotPasswordRequest request)
        {
            return Ok(await _authService.ForgotPassword(request));
        }

        [HttpPost("reset-password")]
        public async Task<ActionResult<ResetPasswordResponse>> ResetPassword(ResetPasswordRequest request)
        {
            return Ok(await _authService.ResetPassword(request));
        }
    }
}
