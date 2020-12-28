using System.ComponentModel.DataAnnotations;

namespace ProyectoFinal_HG.Models
{
    public class Disenador
    {
        public int Id { get; set; }
        [Display(Name = "Nombre")]
        public string Name { get; set; }
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
        [Display(Name = "Telefono")]
        public string Phone { get; set; }
        [Display(Name = "Correo Electronico")]
        public string Email { get; set; }
        [Display(Name="Contacto")]
        public string Contact { get; set; }
    }
}