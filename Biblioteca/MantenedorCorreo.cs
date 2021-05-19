using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class MantenedorCorreo
    {
        SmtpClient cliente;
        MailMessage mm;

        //correo de origen
        string usuario = "geal.noreply@gmail.com";
        string clave = "geal1234";

        const string cuerpohtml1 = "...";
        const string cuerpohtml2 = "...";

        public MantenedorCorreo()
        {
            cliente = new SmtpClient();
            cliente.Port = 587;
            cliente.Host = "smtp.gmail.com";
            cliente.EnableSsl = true;
            cliente.Timeout = 10000;
            cliente.DeliveryMethod = SmtpDeliveryMethod.Network;
            cliente.UseDefaultCredentials = false;
            cliente.Credentials = new System.Net.NetworkCredential(usuario, clave);

        }

        public bool Enviar(string destinatario, string asunto, string mensaje)
        {
            string cuerpo = "";
            cuerpo = mensaje;
            mm = new MailMessage(usuario, destinatario, asunto, cuerpo);
            mm.IsBodyHtml = true;
            mm.BodyEncoding = UTF8Encoding.UTF8;
            mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

            cliente.Send(mm);

            return true;
        }
    }
}
