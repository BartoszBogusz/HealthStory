using HealthStory.Web.Entities;
using HealthStory.Web.Infrastructure;
using Microsoft.EntityFrameworkCore;
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
        private readonly HealthStoryContext _context;

        public UserBloodTestProvider(HealthStoryContext context)
        {
            _context = context;
        }

        public Task<UserBloodTestDto> GetAsync(int bloodTestInfoId)
        {
            var item = _context.BloodTestsInfo
              .Where(x => x.BloodTestInfoId == bloodTestInfoId && !x.IsDeleted)
              .Select(x => new UserBloodTestDto
              {
                  BloodTestId = x.BloodTestInfoId,
                  Name = x.Name,
                  Description = x.Description,
                  Substances = x.BloodTestsSubstancesInfo.Select(s => new UserBloodTestSubstanceDto
                  {
                      SubstanceInfoId = s.SubstanceInfo.SubstanceInfoId,
                      Name = s.SubstanceInfo.Name
                  }).ToList()
              }).FirstAsync();
            return item;
        }
    }
}
