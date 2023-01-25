using System.Net.Mail;
using System.Net;

namespace EmailServiceApi.Services
{
    public class EmailService
    {
        private string smtpAdress => "smtp.gmail.com";
        private int portNumber => 587;
        private string emailFromAdress => "sendmail.dotnetnapratica@gmail.com";
        private string password => "dotnet100";

        public void AddEmailsToMailMessage(MailMessage mailMessage, string[] emails)
        {
            foreach (var email in emails)
            {
                mailMessage.To.Add(email);
            }
        }

        public void SendMail(string[] emails, string subject, string body, bool isHtml = false)
        {
            using (MailMessage mailMessage = new MailMessage())
            {
                mailMessage.From = new MailAddress(emailFromAdress);
                AddEmailsToMailMessage(mailMessage, emails);
                mailMessage.Subject = subject;
                mailMessage.Body = body;
                mailMessage.IsBodyHtml = isHtml;
             

                using (SmtpClient smtp = new SmtpClient(smtpAdress, portNumber))
                {
                    smtp.EnableSsl = true;
                    smtp.Credentials = new NetworkCredential(emailFromAdress, password);
                    smtp.Send(mailMessage);
                }

            }
        }
    }
}
