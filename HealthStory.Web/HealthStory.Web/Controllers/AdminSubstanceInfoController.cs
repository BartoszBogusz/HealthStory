using HealthStory.Web.Application.AdminSubstance;
using HealthStory.Web.Application.AdminUnits;
using HealthStory.Web.Application.Units.SelectList;
using HealthStory.Web.Models.SubstanceInfo;
using Microsoft.AspNetCore.Mvc;

namespace HealthStory.Web.Controllers
{
    public class AdminSubstanceInfoController : Controller
    {
        private readonly IUnitSelectListProvider _unitSelectListProvider;
        private readonly IAdminSubstanceInfoService _adminSubstanceInfoService;

        public AdminSubstanceInfoController(IUnitSelectListProvider unitSelectListProvider,
            IAdminSubstanceInfoService adminSubstanceInfoService)
        {
            _unitSelectListProvider = unitSelectListProvider;
            _adminSubstanceInfoService = adminSubstanceInfoService;
        }

        public IActionResult Index()
        {
            var model = _adminSubstanceInfoService.Get();
            return View(model);
        }

        public IActionResult Create()
        {
            var unitList = _unitSelectListProvider.Get();
            var model = new SubstanceInfoCreateModel
            {
                UnitSelectList = unitList
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(SubstanceInfoCreateModel model)
        {
            _adminSubstanceInfoService.Create(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int substanceId)
        {
            var substance = _adminSubstanceInfoService.Get(substanceId);
            var unitSelectList = _unitSelectListProvider.Get();
            substance.UnitSelectList = unitSelectList;
            return View(substance);
        }

        [HttpPost]
        public IActionResult Edit(SubstanceInfoCreateModel model)
        {
            _adminSubstanceInfoService.Update(model);
            var unitSelectList = _unitSelectListProvider.Get();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int substanceId)
        {
            _adminSubstanceInfoService.Delete(substanceId);
            return RedirectToAction("Index");
        }
    }
}
