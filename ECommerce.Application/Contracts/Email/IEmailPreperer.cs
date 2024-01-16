using ECommerce.Application.Models.Email;

namespace ECommerce.Application.Contracts.Email
{
    public interface IEmailPreperer
    {
        EmailMessage PrepareEmail();
    }
}
