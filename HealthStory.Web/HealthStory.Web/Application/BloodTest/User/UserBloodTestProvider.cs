using HealthStory.Web.Application.AdminBloodTestInfo;
using HealthStory.Web.Infrastructure;
using HealthStory.Web.Models.BloodTestInfo;
using System.Linq;
using System.Threading.Tasks;

namespace HealthStory.Web.Application.BloodTest.User
{
    public interface IUserBloodTestProvider
    {
        Task<UserBloodTestDto> GetAsync(int bloodTestInfoId);
    }
    public class UserBloodTestProvider : IUserBloodTestProvider
    {
        private readonly IAdminBloodTestInfoService _adminBloodTestInfoService;

        public UserBloodTestProvider(IAdminBloodTestInfoService adminBloodTestInfoService)
        {
            _adminBloodTestInfoService = adminBloodTestInfoService;
        }

        public async Task<UserBloodTestDto> GetAsync(int bloodTestInfoId)
        {           
            var bloodTestInfo = await _adminBloodTestInfoService.GetAsync(bloodTestInfoId);
            var userBloodTest = new UserBloodTestDto(bloodTestInfo);
            return userBloodTest;
        }
    }
}
