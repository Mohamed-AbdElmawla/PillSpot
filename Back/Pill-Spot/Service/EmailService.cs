using Microsoft.Extensions.Options;
using Service.Contracts;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Entities.ConfigurationModels;

namespace Service
{
    public class EmailService : IEmailService
    {
        private readonly EmailConfiguration _emailConfig;

        public EmailService(IOptions<EmailConfiguration> emailConfig)
        {
            _emailConfig = emailConfig.Value;
        }

        public async Task SendEmailAsync(string toEmail, string subject, string body)
        {
            using var smtpClient = new SmtpClient(_emailConfig.SmtpServer)
            {
                Port = _emailConfig.SmtpPort,
                Credentials = new NetworkCredential(_emailConfig.SenderEmail, _emailConfig.SenderPassword),
                EnableSsl = true
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress(_emailConfig.SenderEmail),
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };

            mailMessage.To.Add(toEmail);

            await smtpClient.SendMailAsync(mailMessage);
        }
    }
}
