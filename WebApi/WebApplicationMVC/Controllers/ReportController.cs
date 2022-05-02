using Microsoft.AspNetCore.Mvc;

namespace WebApplicationMVC.Controllers
{
    public class ReportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}