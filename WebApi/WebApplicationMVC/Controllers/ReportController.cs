using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApplicationMVC.Config;
using WebApplicationMVC.Repository;

namespace WebApplicationMVC.Controllers
{
    public class ReportController : Controller
    {
        private readonly IReportRepository _repository;
        public ReportController(IReportRepository repository)
        {
            _repository = repository;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new
            {
                data =
                await _repository
                .GetAllAsync(ApiUrl.ApiReportRoute + "candidato/api/customers", HttpContext.Session.GetString("JWTokenReport"))
            });
        }
    }
}