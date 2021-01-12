using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoFinal_HG.Models
{
    public class Venta
    {
        public int Id { get; set; }
        public DateTime DiaVenta { get; set; }
        public float Subtotal { get; set; }
        public float Iva { get; set; }
        public float Total { get; set; }
        public List<ListaVenta> ListaVenta { get; internal set; }
    }
}