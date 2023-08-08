using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace NegocioEMC.Commons
{
    public class EngineEmail
    {
        public static bool EnviarMail(string cuerpo, string emailTo)
        {
            bool result = false;

            try
            {
                SmtpClient servidor = new SmtpClient();
                MailMessage mensaje = new MailMessage();
                mensaje.From = new MailAddress("Sobre Ruedas Valencia<sobreruedasvalencia@hotmail.com>");
                mensaje.Subject = "Sobre Ruedas Valencia " + DateTime.Now.Date;
                mensaje.SubjectEncoding = System.Text.Encoding.UTF8;
                mensaje.Body = cuerpo;
                mensaje.BodyEncoding = System.Text.Encoding.UTF8;
                mensaje.IsBodyHtml = true;
                mensaje.To.Add(new MailAddress(emailTo));
                //if (pathAdjunto != string.Empty) { mensaje.Attachments.Add(new Attachment(pathAdjunto)); }
                servidor.Credentials = new System.Net.NetworkCredential("sobreruedasvalencia@hotmail.com", "Sobreruedas2023"); //captura321afirme captura123.
                servidor.Port = 587;
                servidor.Host = "smtp-mail.outlook.com";
                servidor.DeliveryMethod = 0;
                servidor.EnableSsl = true;
                servidor.Send(mensaje);
                mensaje.Dispose();
                result = true;
            }
            catch(Exception ex) 
            {
               var error = ex.Message;
               return result;
            }

            return result;
        }
    }
}
