using System.ComponentModel.DataAnnotations;


namespace Udemy.Models
{
    public class AlumnoCE
    {
        public int ID { get; set; }
        [Required]
        [Display(Name = "Ingrese Nombres")]
        public string Nombres { get; set; }
        [Required]
        [Display(Name = "Ingrese Apellidos")]
        public string Apellidos { get; set; }
        [Required]
        [Display(Name = "Ingrese Edad")]
        public int Edad { get; set; }
        [Required]
        [Display(Name = "Sexo del Alumno")]
        public string Sexo { get; set; }
        [Required]
        [Display(Name = "Ciudad")]
        public int CodCiudad { get; set; }

    }

    [MetadataType(typeof(AlumnoCE))]
    public partial class Alumno
    { 
        public string NombreCompleto { get { return Nombres + " " + Apellidos; } }
    }
}