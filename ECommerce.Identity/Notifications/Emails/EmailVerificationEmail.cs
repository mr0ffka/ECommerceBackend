using ECommerce.Application.Contracts.Email;
using ECommerce.Application.Models.Email;
using ECommerce.Identity.Models;
using Microsoft.Extensions.Configuration;

namespace ECommerce.Identity.Notifications.Emails
{
    public class EmailVerificationEmail : IEmailPreperer
    {
        private readonly IConfiguration _configuration;
        private readonly AppUser _user;
        private readonly string _token;

        public EmailVerificationEmail(IConfiguration configuration, AppUser user, string token)
        {
            _configuration = configuration;
            _user = user;
            _token = token;
        }

        public EmailMessage PrepareEmail()
        {
            var message = new EmailMessage();

            var emailBody = "Please confirm your email address <a target=\"_blank\" href=\"{0}\">Click here!</a>";
            var link = _configuration["OriginUrl"] + "/auth/verify-email?id=" + _user.Id + "&token=" + _token;
            var body = String.Format(emailBody, link);

            message.ToAddress = _user.Email;
            message.ToName = _user.FirstName + " " + _user.LastName;
            message.Subject = "ECommerce: Email confirmation";
            message.TextBody = body;
            message.HtmlBody = body;

            return message;
        }
    }
}
