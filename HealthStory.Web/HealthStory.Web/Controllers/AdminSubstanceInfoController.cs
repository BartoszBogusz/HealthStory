using HealthStory.Web.Application.AdminSubstance;
using HealthStory.Web.Application.Units.SelectList;
using HealthStory.Web.Models.SubstanceInfo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HealthStory.Web.Controllers
{
    [Authorize]
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

        public async Task<ActionResult<List<SubstanceInfoDto>>> Index()
        {
            var model = await _adminSubstanceInfoService.GetAsync();
            return View(model);
        }

        public async Task<ActionResult> Create()
        {
            var unitList = _unitSelectListProvider.GetAsync();
            var model = new SubstanceInfoCreateModel
            {
                UnitSelectList = await unitList
            };
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Create(SubstanceInfoCreateModel model)
        {
            await _adminSubstanceInfoService.CreateAsync(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int substanceId)
        {
            var substance = await _adminSubstanceInfoService.GetAsync(substanceId);
            var unitSelectList = _unitSelectListProvider.GetAsync();
            substance.UnitSelectList = await unitSelectList;
            return View(substance);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(SubstanceInfoCreateModel model)
        {
            await _adminSubstanceInfoService.UpdateAsync(model);
            var unitSelectList = _unitSelectListProvider.GetAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int substanceId)
        {
            await _adminSubstanceInfoService.DeleteAsync(substanceId);
            return RedirectToAction("Index");
        }
    }
}
