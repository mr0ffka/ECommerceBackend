using ECommerce.Application.Contracts.Email;
using ECommerce.Application.Models.Email;
using ECommerce.Application.Models.Identity;
using ECommerce.Identity.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Identity.Notifications.Emails
{
    public class ForgotPasswordEmail : IEmailPreperer
    {
        private readonly IConfiguration _configuration;
        private readonly AppUser _user;
        private readonly string _token;

        public ForgotPasswordEmail(IConfiguration configuration, AppUser user, string token)
        {
            _configuration = configuration;
            _user = user;
            _token = token;
        }

        public EmailMessage PrepareEmail()
        {
            var message = new EmailMessage();

            var emailBody = "Reset your password <a target=\"_blank\" href=\"{0}\">Click here!</a>";
            var link = _configuration["OriginUrl"] + "/auth/reset-password?id=" + _user.Id + "&token=" + _token;
            var body = String.Format(emailBody, link);

            message.ToAddress = _user.Email;
            message.ToName = _user.FirstName + " " + _user.LastName;
            message.Subject = "ECommerce: Reset password";
            message.TextBody = body;
            message.HtmlBody = body;

            return message;
        }
    }
}
