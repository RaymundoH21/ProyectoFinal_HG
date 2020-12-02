using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal_HG.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(150)]
        [Display(Name ="Categoria")]
        public string Nombre { get; set; }
        public ICollection<Ropa> Ropas { get; set; }
    }
}