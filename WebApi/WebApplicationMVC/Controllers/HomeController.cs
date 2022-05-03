#region Utils
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApplicationMVC.Config;
using WebApplicationMVC.Models;
using WebApplicationMVC.Repository;
#endregion

namespace WebApplicationMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAccountRepository _repository;

        public HomeController(ILogger<HomeController> logger, IAccountRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        #region Login
        [HttpGet]
        public IActionResult Login()
        {
            UserModel user = new UserModel();
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserModel model)
        {
            if(!ModelState.IsValid)
                return View();

            UserModel user = await _repository.LoginAsync(ApiUrl.LoginRoute, model);

            if(string.IsNullOrEmpty(user.Token))
            {
                TempData["alert"] = "Información incorrecta";
                return View();
            }

            var Identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                Identity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));

            var principal = new ClaimsPrincipal(Identity);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            HttpContext.Session.SetString("JWToken", user.Token);
            HttpContext.Session.SetString("UserId", user.Id.ToString());

            //Login para reportes
            var UserReport = new UserModel
            {
                UserName = "ucand0021",
                Password = "yNDVARG80sr@dDPc2yCT!"
            };

            var LoginReport = await _repository.LoginAsync(ApiUrl.ApiReportRoute + "candidato/api/login/authenticate", UserReport);
            
            if(!string.IsNullOrEmpty(LoginReport.Data))
            {
                HttpContext.Session.SetString("JWTokenReport", LoginReport.Data);
            }

            return RedirectToAction("Index");
        }

        #endregion

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            HttpContext.Session.SetString("JWToken", "");
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
