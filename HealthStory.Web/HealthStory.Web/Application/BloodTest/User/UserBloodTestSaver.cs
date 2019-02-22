using HealthStory.Web.Infrastructure;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HealthStory.Web.Application.BloodTest.User
{
    public interface IUserBloodTestSaver
    {
        Task SaveAsync(UserBloodTestDto bloodTest, string appUserId);
    }

    public class UserBloodTestSaver : IUserBloodTestSaver
    {
        private readonly HealthStoryContext _context;

        public UserBloodTestSaver(HealthStoryContext context)
        {
            _context = context;
        }

        public async Task SaveAsync(UserBloodTestDto bloodTest, string appUserId)
        {
            var now = DateTime.Now;
            var appUserBloodTestValues = bloodTest.Substances
                .Select(x => new Entities.AppUserBloodTestValue
                {
                    AppUserId = appUserId,
                    SubstanceInfoId = x.SubstanceInfoId,
                    BloodTestInfoId = bloodTest.BloodTestId,
                    Value = x.Value,
                    CreateDate = now
                }).ToList();
            await _context.AppUserBloodTestValues.AddRangeAsync(appUserBloodTestValues);
            await _context.SaveChangesAsync();
        }
    }
}
