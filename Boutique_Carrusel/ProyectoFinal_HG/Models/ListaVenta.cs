using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProyectoFinal_HG.Models
{
    public class ListaVenta
    {
        public int Id { get; set; }
        public int VentaId { get; set; }
        [ForeignKey("VentaId")]
        public int RopaId { get; set; }
        [ForeignKey("RopaId")]
        public int Cantidad { get; set; }
        public float Total { get; set; }
    }
}