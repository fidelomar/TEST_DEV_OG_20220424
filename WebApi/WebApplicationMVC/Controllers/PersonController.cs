using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApplicationMVC.Models;

namespace WebApplicationMVC.Controllers
{
    public class PersonController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddPerson([FromForm] PersonModel person)
        {
            if (!ModelState.IsValid)
                return View();

            return View("SuccessPage");
        }
    }
}
