using HealthStory.Web.Application.BloodTest.User;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HealthStory.Web.Controllers
{
    public class BloodTestController : Controller
    {
        private readonly IUserBloodTestProvider _userBloodTestProvider;
        private readonly IUserBloodTestSaver _userBloodTestSaver;

        public BloodTestController(IUserBloodTestProvider userBloodTestProvider,
            IUserBloodTestSaver userBloodTestSaver )
        {
            _userBloodTestProvider = userBloodTestProvider;
            _userBloodTestSaver = userBloodTestSaver;
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
    }
}