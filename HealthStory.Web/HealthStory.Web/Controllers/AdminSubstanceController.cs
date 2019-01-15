using HealthStory.Web.Application.Units.SelectList;
using HealthStory.Web.Models.SubstanceDefinition;
using Microsoft.AspNetCore.Mvc;

namespace HealthStory.Web.Controllers
{
    public class AdminSubstanceController : Controller
    {
        private readonly IUnitSelectListProvider _unitSelectListProvider;

        public AdminSubstanceController(IUnitSelectListProvider unitSelectListProvider)
        {
            _unitSelectListProvider = unitSelectListProvider;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            var unitList = _unitSelectListProvider.Get();
            var model = new SubstanceDefinitionCreateModel
            {
                UnitSelectList = unitList
            };
            return View(model);
        }
    }
}
