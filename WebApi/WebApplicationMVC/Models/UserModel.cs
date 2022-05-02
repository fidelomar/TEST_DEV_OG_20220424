using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationMVC.Models
{
    public class UserModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Información requerida")]
        [DisplayName("Usuario")]
        public string UserName { get; set; }
        
        [Required(ErrorMessage = "Información requerida")]        
        [DisplayName("Contraseña")]
        public string Password { get; set; }
    }
}