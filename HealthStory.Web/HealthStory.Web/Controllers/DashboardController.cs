using HealthStory.Web.Application.Dashboard.AvailableTest;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public async Task<ActionResult<List<DashboardBloodTestViewModel>>> Index()
        {
            var model = await _dashboardAvailableTestsProvider.GetAsync();
            return View(model);
        }
    }
}