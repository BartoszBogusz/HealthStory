using HealthStory.Web.Infrastructure;
using System;
using System.Linq;
using System.Threading.Tasks;
using HealthStory.Web.Entities;
using Microsoft.EntityFrameworkCore;

namespace HealthStory.Web.Application.BloodTest.User
{
    public interface IUserBloodTestEditor
    {
        Task EditAsync(UserBloodTestDto bloodTest, string appUserId);
    }

    public class UserBloodTestEditor : IUserBloodTestEditor
    {
        private readonly HealthStoryContext _context;

        public UserBloodTestEditor(HealthStoryContext context)
        {
            _context = context;
        }

        public async Task SaveAsync(UserBloodTestDto bloodTest, string appUserId)
        {
            var now = DateTime.Now;
            var id = Guid.NewGuid();
            var appUserBloodTestValues = bloodTest.Substances
                .Select(x => new Entities.AppUserBloodTestValue
                {
                    AppUserId = appUserId,
                    SubstanceInfoId = x.SubstanceInfoId,
                    BloodTestInfoId = bloodTest.BloodTestId,
                    Value = x.Value,
                    CreateDate = now,
                    Id = id
                }).ToList();
            await _context.AppUserBloodTestValues.AddRangeAsync(appUserBloodTestValues);
            await _context.SaveChangesAsync();
        }

        public async Task EditAsync(UserBloodTestDto bloodTest, string appUserId)
        {
            var dbBloodTestIds = await _context.AppUserBloodTestValues
                                    .Where(x => x.Id == bloodTest.Id && !x.IsDeleted)
                                    .Select(x => x.AppUserBloodTestValueId)
                                    .ToListAsync();

            var newSubstances = bloodTest.Substances.Select(x => x.AppUserBloodTestValueId).ToList();

            var toAdd = newSubstances.Except(dbBloodTestIds)
                .Select(x => new AppUserBloodTestValue
                {
                    // .. 
                    // ..
                }).ToList();

            await _context.AppUserBloodTestValues.AddRangeAsync(toAdd);

            // ... toUpdate
            // ... toRemove
        }
    }
}
