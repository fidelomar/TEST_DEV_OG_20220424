#region Utils
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApplicationMVC.Config;
using WebApplicationMVC.Models;
using WebApplicationMVC.Repository;
#endregion
namespace WebApplicationMVC.Controllers
{
    public class PersonsController : Controller
    {
        private readonly IPersonRepository _personRepository;
        public PersonsController(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        public IActionResult Index()
        {
            return View(new PersonModel() { }); 
        }        

        [HttpGet]
        public async Task<IActionResult> GetAllPersons()
        {
            return Json(new { data = await _personRepository.GetAllAsync(ApiUrl.PersonsRoute) });
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
