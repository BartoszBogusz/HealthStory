using HealthStory.Web.Application.AdminUnits;
using HealthStory.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace HealthStory.Web.Controllers
{
    public class AdminUnitController : Controller
    {
        private readonly IAdminUnitService _adminUnitService;

        public AdminUnitController(IAdminUnitService adminUnitService)
        {
            _adminUnitService = adminUnitService;
        }

        public ActionResult Index()
        {
            var list = _adminUnitService.Get();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(AdminUnitsDto model)
        {
            _adminUnitService.Create(model);
            return RedirectToAction("Index");
        }
    }
}