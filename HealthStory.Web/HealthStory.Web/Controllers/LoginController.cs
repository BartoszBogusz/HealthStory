using HealthStory.Web.Application.Login;
using HealthStory.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace HealthStory.Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginResolver _loginResolver;

        public LoginController(ILoginResolver loginResolver)
        {
            _loginResolver = loginResolver;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserLoginDto model)
        {
            _loginResolver.Login(model);

            if (_loginResolver.Login(model) == true)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

    }
}
