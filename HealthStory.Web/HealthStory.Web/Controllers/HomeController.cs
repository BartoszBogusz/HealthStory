using HealthStory.Web.Models.BloodTest;
using Microsoft.AspNetCore.Mvc;

namespace HealthStory.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(CreateBloodTestViewModel model)
        {
            //ViewBag.Data = string.Join(",", dynamicField ?? new string[] { });
            return View();
        }
        
    }
}
