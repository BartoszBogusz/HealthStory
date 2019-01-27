using HealthStory.Web.Models.BloodTestInfo;
using Microsoft.AspNetCore.Mvc;

namespace HealthStory.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
