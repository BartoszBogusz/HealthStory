using HealthStory.Web.Application.AdminBloodTestInfo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HealthStory.Web.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly IAdminBloodTestInfoService _adminBloodTestService;

        public DashboardController(IAdminBloodTestInfoService adminBloodTestInfoService)
        {
            _adminBloodTestService = adminBloodTestInfoService;
        }

        public IActionResult Index()
        {
            var model = _adminBloodTestService.Get();
            return View(model);
        }
    }
}