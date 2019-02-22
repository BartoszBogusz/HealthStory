using HealthStory.Web.Infrastructure;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace HealthStory.Web.Application.BloodTest.User.History
{
    public interface IUserBloodTestHistoryProvider
    {
        Task<List<UserBloodTestDto>> Get(int bloodTestId, string userId);
    }
    public class UserBloodTestHistoryProvider : IUserBloodTestHistoryProvider
    {
        private readonly HealthStoryContext _context;

        public UserBloodTestHistoryProvider(HealthStoryContext context)
        {
            _context = context;
        }

        public async Task<List<UserBloodTestDto>> Get(int bloodTestId, string userId)
        {
            var tests = await _context.AppUserBloodTestValues
                .Where(x => x.AppUserId == userId)
                .GroupBy(x => new { x.BloodTestInfoId, x.CreateDate })
                .Select(x => new UserBloodTestDto
                {
                    BloodTestId = x.Key.BloodTestInfoId,
                    CreateDate = x.Key.CreateDate,
                    Substances = x.Select(sub => new UserBloodTestSubstanceDto
                    {
                        Name = sub.SubstanceInfo.Name,
                        Value = sub.Value,
                        SubstanceInfoId = sub.SubstanceInfoId
                    }).ToList()
                })
                .ToListAsync();
            return tests;
        }
    }
}
