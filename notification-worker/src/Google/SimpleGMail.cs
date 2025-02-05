using System.Net.Mail;
using System.Net;

namespace Google
{
    class SimpleGMail
    {
        private SmtpClient smtpClient;

        public SimpleGMail()
        {
            smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential("notificacao.fiap.g19@gmail.com", "ogxldnmuzryxfpxd");
        }

        public bool Send(String ToAddress, String Subject, String BodyText, ref String ErrorMessage)
        {
            bool result;

            MailMessage mailMessage = new MailMessage();
            mailMessage.IsBodyHtml = false;
            mailMessage.From = new MailAddress("notificacao.fiap.g19@gmail.com", "Grupo 19 PosTech FIAP");
            mailMessage.Subject = Subject;
            mailMessage.Body = BodyText;
            mailMessage.To.Add(ToAddress);

            try
            {
                smtpClient.Send(mailMessage);
                result = true;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.ToString();
                result = false;
            }

            return result;
        }


    }

}
