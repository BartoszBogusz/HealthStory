using HealthStory.Web.Application.AdminUnits;
using HealthStory.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HealthStory.Web.Controllers
{
    [Authorize]
    public class AdminUnitController : Controller
    {
        private readonly IAdminUnitService _adminUnitService;

        public AdminUnitController(IAdminUnitService adminUnitService)
        {
            _adminUnitService = adminUnitService;
        }

        public async Task<ActionResult<List<AdminUnitsDto>>> Index()
        {
            var list = await _adminUnitService.GetAsync();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(AdminUnitsDto model)
        {
            await _adminUnitService.CreateAsync(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int unitId)
        {
            var unit = await _adminUnitService.GetAsync(unitId);
            return View(unit);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(AdminUnitsDto model)
        {
            await _adminUnitService.UpdateAsync(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            await _adminUnitService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}