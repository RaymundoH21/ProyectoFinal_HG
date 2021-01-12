using ProyectoFinal_HG.Models;
using Rotativa;
using System;
using System.Collections.Generic;
using System.Linq;
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
            if(Session["carrito"] == null)
            {
                List<CarritoItem> compras = new List<CarritoItem>();
                compras.Add(new CarritoItem(db.Ropas.Find(id), 1));
                Session["carrito"] = compras;
            }
            else
            {
                List<CarritoItem> compras = (List<CarritoItem>)Session["carrito"];
                int IndexExistente = getIndex(id);
                if (IndexExistente == -1)
                {
                    compras.Add(new CarritoItem(db.Ropas.Find(id), 1));
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
            List<CarritoItem> compras = (List<CarritoItem>)Session["carrito"];
            return View();
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