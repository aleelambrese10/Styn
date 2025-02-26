using MailKit.Security;
using MimeKit;

namespace STYN.Application.Services
{
    public interface ISendEmailService
    {
        Task SendEmailAsync(string email, string subject, string message);
    }

    public class SendEmailService : ISendEmailService
    {
        public SendEmailService() { }
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            var emailMessage = new MimeMessage();

            var address = "info@Styn.org";
            var pass = "userB01.";
            emailMessage.From.Add(new MailboxAddress(subject, address));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart("html") { Text = message };
            try
            {

                using (var client = new MailKit.Net.Smtp.SmtpClient())
                {
                    await client.ConnectAsync("smtp.hostinger.com", 465, SecureSocketOptions.Auto);
                    await client.AuthenticateAsync(address, pass);
                    await client.SendAsync(emailMessage);
                    await client.DisconnectAsync(true);
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }



    }
}

