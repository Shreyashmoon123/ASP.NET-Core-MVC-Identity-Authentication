using System.Net;
using System.Net.Mail;
namespace EmailSending.Helper
{
    public class EmailHelper
    {
        public bool SendMail(string to, string subject, string msg)
        {
            MailMessage message = new MailMessage();
            SmtpClient smtpClient = new SmtpClient();

            message.From = new MailAddress("shreyashkatiyar404@gmail.com");
            message.To.Add(to);
            message.Subject = subject;
            message.IsBodyHtml = true;
            message.Body = msg;
            smtpClient.Port = 587;
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Host = "smtp.gmail.com";
            smtpClient.Credentials = new NetworkCredential("shreyashkatiyar404@gmail.com", "btrhbhozeziafrpt");
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            try
            {
                smtpClient.Send(message);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception Occured :" + ex.Message);
                return false;
            }
        }
    }
}
