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
        [StringLength(10, MinimumLength = 4, ErrorMessage ="La contraseña debe tener entre 4 y 10 caracteres")]
        public string Password { get; set; }
        public string Token { get; set; }
    }
}