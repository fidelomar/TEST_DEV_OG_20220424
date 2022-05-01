using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApplicationMVC.Models;

namespace WebApplicationMVC.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PostLogin([FromForm] LoginModel login)
        {
            if (!ModelState.IsValid)
                return View();
            
            return View("SuccessPage");
        }
    }
}
