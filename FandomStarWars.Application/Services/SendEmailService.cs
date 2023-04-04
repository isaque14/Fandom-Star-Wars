using FandomStarWars.Application.CQRS.BaseResponses;
using FandomStarWars.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace FandomStarWars.Application.Services
{
    public class SendEmailService : ISendEmailService
    {
        private readonly IConfiguration _configuration;
        private readonly ISendGridClient _sendGridClient;

        public SendEmailService(IConfiguration configuration, ISendGridClient sendGridClient)
        {
            _configuration = configuration;
            _sendGridClient = sendGridClient;
        }

        public async Task<GenericResponse> SendEmail(string email, string subject, string content)
        {
            string fromEmail = _configuration.GetSection("SendGridEmailSettings")
            .GetValue<string>("FromEmail");

            string fromName = _configuration.GetSection("SendGridEmailSettings")
            .GetValue<string>("FromName");

            var msg = new SendGridMessage()
            {
                From = new EmailAddress(fromEmail, fromName),
                Subject = subject,
                PlainTextContent = content
            };

            msg.AddTo(email);
            var response = await _sendGridClient.SendEmailAsync(msg);

            if (response.IsSuccessStatusCode)
                return new GenericResponse
                {
                    IsSuccessful = true,
                    Message = "Email Send Successfully"
                };

            else
                return new GenericResponse
                {
                    IsSuccessful = false,
                    Message = "Email Sending Failed"
                };
        }
    }
}
