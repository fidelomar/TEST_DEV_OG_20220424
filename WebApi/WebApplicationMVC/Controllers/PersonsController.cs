#region Utils
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
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
            return Json(new { data = 
                await _personRepository
                .GetAllAsync(ApiUrl.PersonRoute+"GetPersons", HttpContext.Session.GetString("JWToken")) });
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
            
            person.UserId = Convert.ToInt32(HttpContext.Session.GetString("UserId"));
            await _personRepository.CreateAsync(ApiUrl.PersonRoute+"AddPerson", person, HttpContext.Session.GetString("JWToken"));
            
            return RedirectToAction(nameof(Index));
        }
        #endregion
        #region Edit
        [HttpGet]
        public async Task<IActionResult> EditPerson(int? Id)
        {
            PersonModel person = new PersonModel();

            if (Id == null)
                return NotFound();

            person = await _personRepository
                .GetAsync(
                ApiUrl.PersonRoute + "GetPerson?id=", Id.GetValueOrDefault(), HttpContext.Session.GetString("JWToken"));

            if(person == null)
            {
                return NotFound();
            }

            return View(person);
        }
        
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> EditPerson(PersonModel person)
        {
            if (!ModelState.IsValid)
                return View();

            await _personRepository.UpdateAsync(
                ApiUrl.PersonRoute + "PutPerson" , person, HttpContext.Session.GetString("JWToken"));
            
            return RedirectToAction(nameof(Index));
        }
        #endregion
        #region Delete
        [HttpDelete]
        public async Task<IActionResult> DeletePerson(int Id)
        {            
            if (Id == 0)
                return NotFound();

            await _personRepository.DeleteAsync(ApiUrl.PersonRoute + "DeletePerson?id=", Id, HttpContext.Session.GetString("JWToken"));

            return Json(new { success = true, message = "Borrado correctamente" });            
        }
        #endregion
    }
}