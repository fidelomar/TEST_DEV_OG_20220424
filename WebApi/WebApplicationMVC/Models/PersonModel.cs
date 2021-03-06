using Newtonsoft.Json;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationMVC.Models
{
    public class PersonModel
    {
        [Required(ErrorMessage = "Información requerida")]
        [MaxLength(150)]
        [JsonProperty("Nombre")]
        [DisplayName("Nombre")]        
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Información requerida")]
        [MaxLength(150)]
        [JsonProperty("ApellidoPaterno")]
        [DisplayName("Apellido Paterno")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Información requerida")]
        [MaxLength(150)]
        [JsonProperty("ApellidoMaterno")]
        [DisplayName("Apellido Materno")]
        public string LastName { get; set; }        

        [Required(ErrorMessage = "Información requerida")]
        [MaxLength(13)]
        [JsonProperty("RFC")]
        [DisplayName("RFC")]
        public string RFC { get; set; }
        
        [JsonProperty("FechaNacimiento")]
        [DisplayName("Fecha de nacimiento")]
        public string BirthDate { get; set; }
        
        [JsonProperty("UsuarioAgrega")]
        public int UserId { get; set; }

        [JsonProperty("IdPersonaFisica")]
        public int Id { get; set; }
    }
}