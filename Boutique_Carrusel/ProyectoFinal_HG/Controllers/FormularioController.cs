using ProyectoFinal_HG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public ActionResult FormularioCorreo()
        {
            return View();
        }

        public ActionResult Formulario(Formulario model)
        {
            var mensaje = new MailMessage();
            mensaje.Subject = "Confirmacion de compra";
            mensaje.Body = "Gracias por su compra: su compra ha sido verificada y se enviara en breve";
            mensaje.To.Add(model.Destino);

            mensaje.IsBodyHtml = true;

            var smtp = new SmtpClient();

            return RedirectToAction("Index");
        }
    }
}