using Microsoft.AspNetCore.Identity;

namespace Web.Entities
{
    public class ApplicationUser : IdentityUser
    {
        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        public int UserId { get; set; }

    }
}
