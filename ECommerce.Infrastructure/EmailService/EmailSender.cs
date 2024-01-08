using ECommerce.Application.Contracts.Email;
using ECommerce.Application.Contracts.Logging;
using ECommerce.Application.Models.Email;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using System.Text.Json;

namespace ECommerce.Infrastructure.EmailService
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailSettings _settings;
        private readonly IAppLogger<EmailSender> _logger;

        public EmailSender(IOptions<EmailSettings> settings, IAppLogger<EmailSender> logger)
        {
            _settings = settings.Value;
            _logger = logger;
        }

        public async Task<bool> SendEmailAsync(EmailMessage message)
        {
            try
            {
                using (MimeMessage emailMessage = new MimeMessage())
                {
                    MailboxAddress emailFrom = new MailboxAddress(_settings.SenderName, _settings.SenderEmail);
                    emailMessage.From.Add(emailFrom);
                    MailboxAddress emailTo = new MailboxAddress(message.ToName, message.ToAddress);
                    emailMessage.To.Add(emailTo);

                    // you can add the CCs and BCCs here.
                    //emailMessage.Cc.Add(new MailboxAddress("Cc Receiver", "cc@example.com"));
                    //emailMessage.Bcc.Add(new MailboxAddress("Bcc Receiver", "bcc@example.com"));

                    emailMessage.Subject = message.Subject;

                    BodyBuilder emailBodyBuilder = new BodyBuilder();
                    emailBodyBuilder.TextBody = message.TextBody;
                    emailBodyBuilder.HtmlBody = message.HtmlBody;

                    emailMessage.Body = emailBodyBuilder.ToMessageBody();

                    using (SmtpClient mailClient = new SmtpClient())
                    {
                        if (_settings.UseSsl)
                            await mailClient.ConnectAsync(_settings.Server, _settings.Port, MailKit.Security.SecureSocketOptions.StartTls);
                        else
                            await mailClient.ConnectAsync(_settings.Server, _settings.Port);

                        if (!_settings.WithoutCredentials)
                            await mailClient.AuthenticateAsync(_settings.UserName, _settings.Password);

                        await mailClient.SendAsync(emailMessage);
                        await mailClient.DisconnectAsync(true);
                    }

                    _logger.LogInfo(JsonSerializer.Serialize(emailMessage));
                }

                return true;
            }
            catch (Exception ex)
            {
                // Exception Details
                _logger.LogErr(ex.Message);
                return false;
            }
        }
    }
}
