using HealthStory.Web.Application.AdminBloodTestInfo;
using HealthStory.Web.Application.Dashboard.AvailableTest;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HealthStory.Web.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly IDashboardAvailableTestsProvider _dashboardAvailableTestsProvider;

        public DashboardController(IDashboardAvailableTestsProvider dashboardAvailableTestsProvider)
        {
            _dashboardAvailableTestsProvider = dashboardAvailableTestsProvider;
        }

        public IActionResult Index()
        {
            var model = _dashboardAvailableTestsProvider.Get();
            return View(model);
        }
    }
}