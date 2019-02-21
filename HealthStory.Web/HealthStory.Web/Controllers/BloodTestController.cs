using HealthStory.Web.Application.BloodTest.User;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HealthStory.Web.Controllers
{
    public class BloodTestController : Controller
    {
        private readonly IUserBloodTestProvider _userBloodTestProvider;

        public BloodTestController(IUserBloodTestProvider userBloodTestProvider)
        {
            _userBloodTestProvider = userBloodTestProvider;
        }

        public async Task<IActionResult> New(int bloodTestId)
        {
            var bloodTest = await _userBloodTestProvider.GetAsync(bloodTestId);
            return View(bloodTest);
        }
    }
}