using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Información requerida")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Información requerida")]
        public string Password { get; set; }
    }
}
