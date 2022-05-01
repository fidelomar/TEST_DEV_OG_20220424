using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationMVC.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Información requerida")]
        [MaxLength(20)]
        [DisplayName("Usuario")]
        public string UserName { get; set; }
        
        [Required(ErrorMessage = "Información requerida")]
        [MaxLength(15)]
        [DisplayName("Contraseña")]
        public string Password { get; set; }
    }
}