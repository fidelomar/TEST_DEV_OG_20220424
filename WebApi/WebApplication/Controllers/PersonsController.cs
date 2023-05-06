#region Utils
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Web.Entities.Data;
using Web.Repository.UnitOfWork;
using WebApplication.Strategy;
#endregion

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : Controller
    {
        private readonly DatabaseContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public PersonsController(
            IUnitOfWork unitOfWork,
            DatabaseContext context)
        {
            _unitOfWork = unitOfWork;
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        #region Add
        //[Authorize]
        [HttpPost]
        [Route("AddPerson")]
        public async Task<IActionResult> AddPerson([FromBody] TbPersonasFisica person)
        {
            var context = new PersonStrategyContext(new PersonStrategy());
            await context.AddPerson(person, _context);            
            return Ok(new TbPersonasFisica());
        }
        #endregion

        #region Edit
        [Authorize]
        [HttpPut]
        [Route("PutPerson")]
        public async Task<IActionResult> PutPerson([FromBody] TbPersonasFisica personasFisica)
        {
            var context = new PersonStrategyContext(new PersonStrategy());
            await context.UpdatePerson(personasFisica, _context);            
            return Ok(new TbPersonasFisica());
        }
        #endregion

        #region Delete
        [Authorize]
        [HttpDelete]
        [Route("DeletePerson")]
        public async Task<IActionResult> DeletePerson(int Id)
        {
            var context = new PersonStrategyContext(new PersonStrategy());
            await context.DeletePerson(Id, _context);
            return Ok(new TbPersonasFisica());
        }
        #endregion

        #region Get
        [Authorize]
        [HttpGet]
        [Route("GetPerson")]
        public async Task<IActionResult> GetPerson(int Id)
        {
            if(Id==0)
                return NotFound();

            TbPersonasFisica tbPersonasFisica = null;

            var context = new PersonStrategyContext(new PersonStrategy());
            tbPersonasFisica = await context.GetPerson(_unitOfWork, Id);

            return Ok(tbPersonasFisica);
        }
        #endregion

        #region GetAll
        [Authorize]
        [HttpGet]
        [Route("GetPersons")]
        public async Task<IEnumerable<TbPersonasFisica>> GetPersons()
        {
            IEnumerable<TbPersonasFisica> tbPersonasFisica = null;
            var context = new PersonStrategyContext(new PersonStrategy());
            tbPersonasFisica = await context.GetPersons(_unitOfWork);

            return tbPersonasFisica;
        }
        #endregion

    }
}