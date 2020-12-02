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
        public string ApplicationUser { get; set; }
        [Display(Name="Modista")]
        [ForeignKey("ApplicationUser")]
        public ApplicationUser Modista { get; set; }
        [Display(Name ="Descripcion de la prenda")]
        public string Descripcion { get; set; }
        [Display(Name ="Precio")]
        public string Precio { get; set; }
        [Display(Name = "Categoria")]
        public int CategoriaId { get; set; }
        [ForeignKey("CategoriaId")]
        public Categoria Categoria { get; set; }
    }
}