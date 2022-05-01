using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationMVC.Models
{
    public class PersonModel
    {
        [Required(ErrorMessage = "Información requerida")]
        [MaxLength(150)]
        [DisplayName("Nombre")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Información requerida")]
        [MaxLength(150)]
        [DisplayName("Apellido Paterno")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Información requerida")]
        [MaxLength(150)]
        [DisplayName("Apellido Materno")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Información requerida")]
        [MaxLength(150)]
        [DisplayName("RFC")]
        public string RFC { get; set; }

        [MaxLength(150)]
        [DisplayName("Fecha de nacimiento")]
        public string BirthDate { get; set; }
    }
}