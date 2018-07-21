using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;

namespace WebMvcDoAlmoco.Services
{
    // This class is used by the application to send email for account confirmation and password reset.
    // For more details see https://go.microsoft.com/fwlink/?LinkID=532713
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {            
            Execute().Wait();
            return Task.CompletedTask;
        }

        static async Task Execute()
        {
            var apiKey = Environment.GetEnvironmentVariable("SendGrid");
            var client = new SendGridClient("Chave de Acesso");
            var from = new EmailAddress("eoalcantara@gmail.com", "Admi User");
            var subject = "Cadastro de restaurante";
            var to = new EmailAddress("eoalcantara@gmail.com", "Admin User");
            var plainTextContent = "Bora comer";
            var htmlContent = "<strong>Vote!</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }
}
