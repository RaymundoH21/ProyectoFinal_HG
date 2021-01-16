using ProyectoFinal_HG.Models;
using Rotativa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace ProyectoFinal_HG.Controllers
{
    public class CarritoController : Controller
    {
        // GET: Carrito
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult AgregarCarrito(int id)
        {
            var user = User.Identity.Name;
            if(Session["carrito"] == null)
            {
                List<CarritoItem> compras = new List<CarritoItem>();
                compras.Add(new CarritoItem(db.Ropas.Find(id), 1, user));
                Session["carrito"] = compras;
            }
            else
            {
                List<CarritoItem> compras = (List<CarritoItem>)Session["carrito"];
                int IndexExistente = getIndex(id);
                if (IndexExistente == -1)
                {
                    compras.Add(new CarritoItem(db.Ropas.Find(id), 1, user));
                }
                else
                {
                    compras[IndexExistente].Cantidad++;
                }
                Session["carrito"] = compras;
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            List<CarritoItem> compras = (List<CarritoItem>)Session["carrito"];
            compras.RemoveAt(getIndex(id));
            return View("AgregarCarrito");
        }

        private int getIndex(int id)
        {
            List<CarritoItem> compras = (List<CarritoItem>)Session["carrito"];
            for (int i = 0; i < compras.Count; i++)
            {
                if (compras[i].Producto.Id == id)
                    return i;
            }
            return -1;
        }

        public ActionResult FinalizarCompra()
        {
            var ComprasRealizadas = string.Empty;
            var HoraCompra = DateTime.Now;
            List<CarritoItem> compras = (List<CarritoItem>)Session["carrito"];
            foreach (var item in compras)
            {
                ComprasRealizadas += "- " + item.Producto.Descripcion + ", " + item.Producto.Precio;
            }
            Formulario F = new Formulario()
            {
                Destino = User.Identity.Name,
                Mensaje = "Su compra en Botique Carrusel se ha realizado con exito " + "\n"
                + "\n" + "Sus productos:"
                + "\n" + ComprasRealizadas 
                + "\n" + "Metodo de pago utilizado: Tarjeta de credito (Visa)."
                + "\n" + "La fecha y hora de su compra fueron: " + HoraCompra + ". ",
                Asunto = "Boutique Carrusel - Confirmacion de compra"
            };

            Enviar(F);
            ViewBag.Message = ("Se ha enviado un correo, para la confirmacion de su compra");
            return View();
        }

        public void Enviar(Formulario F)
        {

            SmtpClient client = new SmtpClient("smtp.gmail.com");
            client.EnableSsl = true;
            client.Port = 587;

            //If you need to authenticate
            client.Credentials = new System.Net.NetworkCredential("raymundo.hirales17@tectijuana.edu.mx", "otakuluffymastersans");
            MailMessage mailMessage = new MailMessage();

            mailMessage.From = new MailAddress("otakujalogearso@gmail.com", "Raymundo");
            mailMessage.To.Add(F.Destino);
            mailMessage.Subject = F.Asunto;
            mailMessage.Body = F.Mensaje;



            client.Send(mailMessage);
            


        }

        public ActionResult Recibo()
        {
            return View();
        }

        public ActionResult Print()
        {
            return new ActionAsPdf("Recibo") {  FileName="Recibo de compra.pdf"};
        }
        
    }
}