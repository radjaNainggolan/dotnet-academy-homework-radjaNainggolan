using Library.RadenRovcanin.Contracts.Services;
using Library.RadenRovcanin.Contracts.Settings;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Library.RadenRovcanin.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _settings;

        public EmailService(IOptions<EmailSettings> settings)
        {
            _settings = settings.Value;
        }

        public async Task Send(string to, string subject, string body)
        {
            var sendGridClient = new SendGridClient(_settings.Key);

            var message = new SendGridMessage
            {
                From = new EmailAddress(_settings.EmailFrom),
                Subject = subject,
                HtmlContent = body,
            };

            message.AddTo(new EmailAddress(to));
            var response = await sendGridClient.SendEmailAsync(message);

            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Body.ReadAsStringAsync();
                throw new Exception($"Unable to send an email {error}");
            }
        }
    }
}
