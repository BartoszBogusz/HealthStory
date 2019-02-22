using HealthStory.Web.Application.BloodTest.User.History;
using HealthStory.Web.Application.Dashboard.AvailableTest;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HealthStory.Web.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly IDashboardAvailableTestsProvider _dashboardAvailableTestsProvider;
        private readonly IUserBloodTestHistoryProvider _userBloodTestHistoryProvider;

        public DashboardController(IDashboardAvailableTestsProvider dashboardAvailableTestsProvider,
            IUserBloodTestHistoryProvider userBloodTestHistoryProvider)
        {
            _dashboardAvailableTestsProvider = dashboardAvailableTestsProvider;
            _userBloodTestHistoryProvider = userBloodTestHistoryProvider;
        }

        public async Task<ActionResult<List<DashboardBloodTestViewModel>>> Index()
        {
            var model = await _dashboardAvailableTestsProvider.GetAsync();
            return View(model);
        }
        
    }
}