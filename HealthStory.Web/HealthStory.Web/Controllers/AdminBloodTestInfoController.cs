using HealthStory.Web.Application.AdminBloodTestInfo;
using HealthStory.Web.Application.AdminSubstance;
using HealthStory.Web.Models.BloodTestInfo;
using Microsoft.AspNetCore.Mvc;

namespace HealthStory.Web.Controllers
{
    public class AdminBloodTestInfoController : Controller
    {
        private readonly IAdminBloodTestInfoService _adminBloodTestService;
        private readonly IAdminSubstanceInfoService _adminSubstanceInfoService;

        public AdminBloodTestInfoController(IAdminBloodTestInfoService adminBloodTestService,
            IAdminSubstanceInfoService adminSubstanceInfoService)
        {
            _adminBloodTestService = adminBloodTestService;
            _adminSubstanceInfoService = adminSubstanceInfoService;
        }

        public IActionResult Index()
        {
            var model = _adminBloodTestService.Get();
            return View(model);
        }

        public IActionResult Create()
        {
            var substanceList = _adminSubstanceInfoService.GetSelectListItems();
            ViewBag.SubstanceList = substanceList;
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateBloodTestInfoViewModel model)
        {
            _adminBloodTestService.Create(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int bloodTestId)
        {
            var bloodTest = _adminBloodTestService.Get(bloodTestId);
            return View(bloodTest);
        }

        [HttpPost]
        public IActionResult Edit(BloodTestInfoDto model)
        {
            _adminBloodTestService.Update(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _adminBloodTestService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}