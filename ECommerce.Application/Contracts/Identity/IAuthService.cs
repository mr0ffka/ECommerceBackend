using ECommerce.Application.Models.Identity;

namespace ECommerce.Application.Contracts.Identity
{
    public interface IAuthService
    {
        Task<AuthResponse> Login(AuthRequest request);
        Task<RegistrationResponse> Register(RegistrationRequest request);
        Task<EmailVerificationResponse> VerifyEmail(EmailVerificationRequest request);
        Task<ForgotPasswordResponse> ForgotPassword(ForgotPasswordRequest request);
        Task<ResetPasswordResponse> ResetPassword(ResetPasswordRequest request);
    }
}
