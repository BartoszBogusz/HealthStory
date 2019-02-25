using HealthStory.Web.Infrastructure;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace HealthStory.Web.Application.BloodTest.User.History
{
    public interface IUserBloodTestHistoryProvider
    {
        Task<List<UserBloodTestDto>> Get(int bloodTestId, string userId);
        Task<List<UserBloodTestSubstanceDto>> GetAsync(Guid id);
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
                .Where(x => x.AppUserId == userId && x.BloodTestInfoId == bloodTestId)
                .GroupBy(x => new { x.BloodTestInfoId, x.CreateDate })
                .Select(x => new UserBloodTestDto
                {
                    Name = x.First().BloodTestInfo.Name,
                    Description = x.First().BloodTestInfo.Description,
                    BloodTestId = x.Key.BloodTestInfoId,
                    CreateDate = x.Key.CreateDate,
                    Id = x.First().Id,
                    Substances = x.Select(sub => new UserBloodTestSubstanceDto
                    {
                        Name = sub.SubstanceInfo.Name,
                        Value = sub.Value,
                        SubstanceInfoId = sub.SubstanceInfoId
                    }).ToList(),
                })
                .ToListAsync();
            return tests;
        }

        public Task<List<UserBloodTestSubstanceDto>> GetAsync(Guid id)
        {
            var subs = _context.AppUserBloodTestValues
                .Where(x => x.Id == id)
                .Select(x => new UserBloodTestSubstanceDto
                {
                    Value = x.Value,
                    Name = x.SubstanceInfo.Name
                })
                .ToListAsync();
             return subs;
        }
    }
}
