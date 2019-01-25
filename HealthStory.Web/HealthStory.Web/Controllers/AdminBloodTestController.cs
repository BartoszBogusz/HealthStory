using HealthStory.Web.Application.AdminBloodTest;
using HealthStory.Web.Models.BloodTest;
using Microsoft.AspNetCore.Mvc;

namespace HealthStory.Web.Controllers
{
    public class AdminBloodTestController : Controller
    {
        private readonly IAdminBloodTestService _adminBloodTestService;

        public AdminBloodTestController(IAdminBloodTestService adminBloodTestService)
        {
            _adminBloodTestService = adminBloodTestService;
        }

        public IActionResult Index()
        {
            var model = _adminBloodTestService.Get();
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateBloodTestViewModel model)
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
        public IActionResult Edit(BloodTestDto model)
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