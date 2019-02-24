using HealthStory.Web.Application.BloodTest.User;
using HealthStory.Web.Application.BloodTest.User.History;
using HealthStory.Web.Application.Dashboard.AvailableTest;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HealthStory.Web.Controllers
{
    public class BloodTestController : Controller
    {
        private readonly IUserBloodTestProvider _userBloodTestProvider;
        private readonly IUserBloodTestSaver _userBloodTestSaver;
        private readonly IDashboardAvailableTestsProvider _dashboardAvailableTestsProvider;
        private readonly IUserBloodTestHistoryProvider _userBloodTestHistoryProvider;

        public BloodTestController(IUserBloodTestProvider userBloodTestProvider,
            IUserBloodTestSaver userBloodTestSaver, 
            IDashboardAvailableTestsProvider dashboardAvailableTestsProvider,
            IUserBloodTestHistoryProvider userBloodTestHistoryProvider)
        {
            _userBloodTestProvider = userBloodTestProvider;
            _userBloodTestSaver = userBloodTestSaver;
            _dashboardAvailableTestsProvider = dashboardAvailableTestsProvider;
            _userBloodTestHistoryProvider = userBloodTestHistoryProvider;
        }

        public async Task<IActionResult> New(int bloodTestId)
        {
            var bloodTest = await _userBloodTestProvider.GetAsync(bloodTestId);
            return View(bloodTest);
        }

        [HttpPost]
        public async Task<ActionResult> Create(UserBloodTestDto model)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await _userBloodTestSaver.SaveAsync(model, userId);       
            return RedirectToAction("Index", "Dashboard");
        }

        public async Task<ActionResult<List<DashboardBloodTestViewModel>>> History(int bloodTestId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var model = await _userBloodTestHistoryProvider.Get(bloodTestId, userId);
            return View(model);
        }

        public async Task<ActionResult<List<UserBloodTestSubstanceDto>>> Details(Guid id)
        {
            var model = await _userBloodTestHistoryProvider.GetAsync(id);
            return View(model);
        }

        public async Task<ActionResult<List<UserBloodTestSubstanceDto>>> Edit(Guid id)
        {
            var model = await _userBloodTestHistoryProvider.GetAsync(id);
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(UserBloodTestSubstanceDto model, Guid id)
        {
            await _userBloodTestHistoryProvider.UpdateAsync(model, id);
            return RedirectToAction("Index");
        }
    }
}