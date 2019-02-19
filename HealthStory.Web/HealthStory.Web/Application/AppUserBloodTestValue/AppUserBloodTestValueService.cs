using HealthStory.Web.Infrastructure;
using HealthStory.Web.Models.AppUserBloodTestValue;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthStory.Web.Application.AppUserBloodTestValue
{
    public interface IAppUserBloodTestValueService
    {
        Task DeleteAsync(int appUserBloodTestValueId);
        Task<List<AppUserBloodTestValueViewModel>> GetAsync();
        Task<AppUserBloodTestValueViewModel> GetAsync(int appUserBloodTestValueId);
    }

    public class AppUserBloodTestValueService : IAppUserBloodTestValueService
    {
        private readonly HealthStoryContext _context;

        public AppUserBloodTestValueService(HealthStoryContext context)
        {
            _context = context;
        }

        public Task<List<AppUserBloodTestValueViewModel>> GetAsync()
        {
            var list = _context.AppUserBloodTestValues
                .Where(x => !x.IsDeleted)
                .Select(x => new AppUserBloodTestValueViewModel
                {
                    AppUserBloodTestValueId = x.AppUserBloodTestValueId,
                    Value = x.Value,
                    CreateDate = x.CreateDate,
                }
                ).ToListAsync();

            return list;
        }

        public async Task DeleteAsync(int appUserBloodTestValueId)
        {
            var appUserBloodTestValue = _context.AppUserBloodTestValues
                .Where(x => x.AppUserBloodTestValueId == appUserBloodTestValueId && !x.IsDeleted)
                .First();

            appUserBloodTestValue.IsDeleted = true;

            await _context.SaveChangesAsync();
        }

        public Task<AppUserBloodTestValueViewModel> GetAsync(int appUserBloodTestValueId)
        {
            var item = _context.AppUserBloodTestValues
                .Where(x => x.AppUserBloodTestValueId == appUserBloodTestValueId && !x.IsDeleted)
                .Select(x => new AppUserBloodTestValueViewModel
                {
                    Value = x.Value,
                    CreateDate = x.CreateDate
                }).FirstAsync();

            return item;

        }
    }
}