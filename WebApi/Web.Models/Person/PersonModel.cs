using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Models
{
    public class PersonModel
    {
        [Required(ErrorMessage = "Información requerida")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Información requerida")]
        public string ApellidoPaterno { get; set; }
        
        [Required(ErrorMessage = "Información requerida")]
        public string ApellidoMaterno { get; set; }

        [Required(ErrorMessage = "Información requerida")]
        public string RFC { get; set; }

        [Required(ErrorMessage = "Información requerida")]
        public DateTime FechaNacimiento { get; set; }

        public string UserId { get; set; }
    }
}
