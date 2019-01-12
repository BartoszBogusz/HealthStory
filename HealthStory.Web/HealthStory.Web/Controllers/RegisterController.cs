using HealthStory.Web.Application.Register;
using HealthStory.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace HealthStory.Web.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IRegisterResolver _registerResolver;

        public RegisterController(IRegisterResolver registerResolver)
        {
            _registerResolver = registerResolver;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(UserRegisterDto model)
        {
            _registerResolver.Register(model);
            return View("Index");
        }

    }
}
