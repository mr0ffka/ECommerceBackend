using ECommerce.Application.Models.Email;

namespace ECommerce.Application.Contracts.Email
{
    public interface IEmailSender
    {
        Task<bool> SendEmailAsync(EmailMessage message);
    }
}
