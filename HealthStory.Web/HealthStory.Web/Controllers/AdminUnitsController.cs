using HealthStory.Web.Application.AdminUnits;
using HealthStory.Web.Infrastructure;
using HealthStory.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace HealthStory.Web.Controllers
{
    public class AdminUnitsController : Controller
    {
        private readonly IAdminUnitsResolver _adminUnitsResolver;
        private readonly HealthStoryContext _healthStoryContext;

        public AdminUnitsController(IAdminUnitsResolver adminUnitsResolver, HealthStoryContext healthStoryContext)
        {
            _adminUnitsResolver = adminUnitsResolver;
            _healthStoryContext = healthStoryContext;
        }

        
 
        public ActionResult Index()
        {
            return View(_healthStoryContext.Units.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddUnit(AdminUnitsDto model)
        {
            _adminUnitsResolver.AddUnit(model);
            return RedirectToAction("Index", "AdminUnits");
        }
    }
}