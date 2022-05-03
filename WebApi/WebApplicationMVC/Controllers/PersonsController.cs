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

        #region Index
        public IActionResult Index()
        {
            return View(new PersonModel() { });
        }
        [HttpGet]
        public async Task<IActionResult> GetAllPersons()
        {
            return Json(new { data = await _personRepository.GetAllAsync(ApiUrl.PersonRoute+"GetPersons") });
        }        
        #endregion
        #region Add
        [HttpGet]
        public IActionResult AddPerson()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddPerson(PersonModel person)
        {
            if (!ModelState.IsValid)
                return View();
            
            person.UserId = 1;

            await _personRepository.CreateAsync(ApiUrl.PersonRoute+"AddPerson", person);
            
            return RedirectToAction(nameof(Index));
        }        
        #endregion
    }
}