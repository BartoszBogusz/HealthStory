using HealthStory.Web.Application.AdminBloodTestInfo;
using HealthStory.Web.Application.AdminSubstance;
using HealthStory.Web.Models.BloodTestInfo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HealthStory.Web.Controllers
{
    [Authorize]
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

        public async Task<ActionResult<List<BloodTestInfoDto>>> Index()
        {
            var model = await _adminBloodTestService.GetAsync();
            return View(model);
        }

        public async Task<ActionResult> Create()
        {
            var substanceList = await _adminSubstanceInfoService.GetSelectListItemsAsync();
            ViewBag.SubstanceList = substanceList;
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateBloodTestInfoViewModel model)
        {
            await _adminBloodTestService.CreateAsync(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int bloodTestId)
        {
            var bloodTest = await _adminBloodTestService.GetAsync(bloodTestId);
            return View(bloodTest);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(BloodTestInfoDto model)
        {
            await _adminBloodTestService.UpdateAsync(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            await _adminBloodTestService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}