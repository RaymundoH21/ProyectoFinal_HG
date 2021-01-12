using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;

namespace ProyectoFinal_HG
{
    public partial class WebMail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                MailMessage msg = new MailMessage();
                msg.From = new MailAddress("raymundo.hirales17@gmail.com");
                msg.To.Add(txtTo.Text);
                msg.Subject = "Confirmacion de Compra";
                msg.Body = "Su compra se ha completado con exito y se enviaran a la brevedad, gracias por su preferencia";

                using (SmtpClient client = new SmtpClient())
                {
                    client.EnableSsl = true;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential("raymundo.hirales17@gmail.com", "otakuluffymastersans");
                    client.Host = "smtp.gmail.com";
                    client.Port = 465;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.Send(msg);
                    Response.Write("Correo enviado con exito");
                }
            }
            catch (Exception ex)
            {

                Response.Write(ex.Message);
            }
        }
    }
}