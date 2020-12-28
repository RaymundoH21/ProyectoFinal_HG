using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProyectoFinal_HG.Models
{
    public class Ropa
    {
        public int Id { get; set; }
        public int DisenadorId { get; set; }
        [ForeignKey("DisenadorId")]
        public Disenador Modista { get; set; }
        [Display(Name = "Cantidad")]
        public int Existencias { get; set; }
        [Display(Name ="Descripcion")]
        public string Descripcion { get; set; }
        [Display(Name ="Precio")]
        public string Precio { get; set; }
        public string Picture { get; set; }
        
    }
}