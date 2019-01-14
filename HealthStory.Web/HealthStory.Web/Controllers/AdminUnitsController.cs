using HealthStory.Web.Application.AdminUnits;
using HealthStory.Web.Infrastructure;
using HealthStory.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace HealthStory.Web.Controllers
{
    public class AdminUnitsController : Controller
    {
        private readonly IAdminUnitsResolver _adminUnitsResolver;

        public AdminUnitsController(IAdminUnitsResolver adminUnitsResolver)
        {
            _adminUnitsResolver = adminUnitsResolver;
        }

        public ActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddUnit(AdminUnitsDto model)
        {
            _adminUnitsResolver.AddUnit(model);
            return View("Index");
        }
    }
}