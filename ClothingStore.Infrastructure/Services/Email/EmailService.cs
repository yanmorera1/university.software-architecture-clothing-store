using ClothingStore.Application.Contracts.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace ClothingStore.Infrastructure.Services.Email
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _settings;
        private readonly ILogger<EmailService> _logger;

        public EmailService(IOptions<EmailSettings> settings, ILogger<EmailService> logger)
        {
            _settings = settings.Value;
            _logger = logger;
        }

        public async Task SendEmailAsync(string to, string subject, string message)
        {
            try
            {
                var msg = CreateMail(subject, to, message);

                using (SmtpClient client = new SmtpClient())
                {
                    client.Credentials = new NetworkCredential(_settings.From, _settings.Password);
                    client.EnableSsl = true;
                    client.Port = int.Parse(_settings.Port);
                    client.Host = _settings.Host;
                    await client.SendMailAsync(msg);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public MailMessage CreateMail(string subject, string to, string message)
        {
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress(_settings.From);
            msg.To.Add(to);
            msg.Subject = subject;
            msg.SubjectEncoding = Encoding.UTF8;

            msg.Body = message;

            msg.BodyEncoding = Encoding.UTF8;

            return msg;
        }
    }
}
