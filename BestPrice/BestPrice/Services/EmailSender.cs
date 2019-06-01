using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;
using SendGrid;
using SendGrid.Helpers.Mail;
using MimeKit;



namespace BestPrice.Services
{
    // This class is used by the application to send email for account confirmation and password reset.
    // For more details see https://go.microsoft.com/fwlink/?LinkID=532713
    public class EmailSender : IEmailSender
    {
        public EmailSender(IOptions<AuthMessageSenderOptions> optionsAccessor)
        {
            Options = optionsAccessor.Value;
        }
        public AuthMessageSenderOptions Options { get; } //set only via Secret Manager
        public Task SendEmailAsync(string email, string subject, string message)
        {
            return Execute("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", subject, message, email);
        }
        public Task Execute(string apiKey, string subject, string message, string email)
        {
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("noreply@TechPG.com", "TechPG"),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message,
                //TemplateId = temp_id
                
            };
            msg.AddTo(new EmailAddress(email));
            //msg.AddSubstitution("--verifyURL--", link);
            //msg.AddSubstitution("--Button--", button_text);
            return client.SendEmailAsync(msg);
        }

        public async Task SendEmailByMailKitAsync(string email, string subject, string body, string typeOfEmail)
        {
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress(typeOfEmail, "prj666group03@gmail.com"));
                message.To.Add(new MailboxAddress("TechPG Developer", email));
                message.Subject = subject;
                message.Body = new TextPart("plain")
                {
                    Text = body
                };

                using (var client = new SmtpClient())
                {
                    client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                    client.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                    client.Authenticate("prj666group03@gmail.com", "Group03...");
                    client.Send(message);
                    client.Disconnect(true);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
