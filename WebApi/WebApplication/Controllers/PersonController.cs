using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Web.Entities.Data;
using Web.Models;
using Web.Repository.UnitOfWork;
using WebApplication.Strategy;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : Controller
    {
        private readonly DatabaseContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public PersonController(
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
        
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddPerson([FromBody] TbPersonasFisica personasFisica)
        {
            var context = new PersonStrategyContext(new PersonStrategy());
            await context.AddPerson(personasFisica, _context);
            //return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(new TbPersonasFisica());
        }

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> PutPerson([FromBody] TbPersonasFisica personasFisica)
        {
            var context = new PersonStrategyContext(new PersonStrategy());
            await context.UpdatePerson(personasFisica, _context);            
            return Ok(new TbPersonasFisica());
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> DeletePerson([FromBody] TbPersonasFisica personasFisica)
        {
            var context = new PersonStrategyContext(new PersonStrategy());
            await context.DeletePerson(personasFisica, _context);
            return Ok(new TbPersonasFisica());
        }

        [Authorize]
        [HttpGet]
        public async Task<TbPersonasFisica> GetPerson([FromBody] TbPersonasFisica personasFisica)
        {
            TbPersonasFisica tbPersonasFisica = null;

            var context = new PersonStrategyContext(new PersonStrategy());
            tbPersonasFisica = await context.GetPerson(_unitOfWork, personasFisica.IdPersonaFisica);

            return tbPersonasFisica;
        }

        [Authorize]
        [HttpGet]
        public async Task<IEnumerable<TbPersonasFisica>> GetPersons([FromBody] TbPersonasFisica personasFisica)
        {
            IEnumerable<TbPersonasFisica> tbPersonasFisica = null;
            var context = new PersonStrategyContext(new PersonStrategy());
            tbPersonasFisica = await context.GetPersons(_unitOfWork);

            return tbPersonasFisica;
        }


    }
}
