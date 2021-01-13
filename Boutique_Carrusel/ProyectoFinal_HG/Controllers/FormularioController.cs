using ProyectoFinal_HG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace ProyectoFinal_HG.Controllers
{
    public class FormularioController : Controller
    {
        // GET: Formulario
        public ActionResult Index()
        {
            return View();
        }

        public void Enviar(string To, string Subject, string Body, HttpPostedFileBase fichero)
        {

            SmtpClient client = new SmtpClient("smtp.gmail.com");
            client.EnableSsl = true;
            client.Port = 587;

            //If you need to authenticate
            client.Credentials = new NetworkCredential("raymundo.hirales17@tectijuana.edu.mx", "otakuluffymastersans");
            MailMessage mailMessage = new MailMessage();

            mailMessage.From = new MailAddress("otakujalogearso@gmail.com", "Raymundo");
            mailMessage.To.Add(To);
            mailMessage.Subject = "Confirmacion de Compra";
            mailMessage.Body = "Su compra se ha completado con exito y se enviaran a la brevedad, gracias por su preferencia";



            client.Send(mailMessage);
            ViewBag.Message = ("Mensaje enviado exitosamente");


        }
        public ActionResult FormularioCorreo()
        {
            var usuario = User.Identity.Name;
            return View();
        }
    }
}