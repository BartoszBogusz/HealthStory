using HealthStory.Web.Infrastructure;
using HealthStory.Web.Models.AppUserBloodTestValue;
using System.Collections.Generic;
using System.Linq;

namespace HealthStory.Web.Application.AppUserBloodTestValue
{
    public interface IAppUserBloodTestValueService
    {
        void Delete(int appUserBloodTestValueId);
        List<AppUserBloodTestValueViewModel> Get();
        AppUserBloodTestValueViewModel Get(int appUserBloodTestValueId);
    }

    public class AppUserBloodTestValueService : IAppUserBloodTestValueService
    {
        private readonly HealthStoryContext _context;

        public AppUserBloodTestValueService(HealthStoryContext context)
        {
            _context = context;
        }

        public List<AppUserBloodTestValueViewModel> Get()
        {
            var list = _context.AppUserBloodTestValues
                .Where(x => !x.IsDeleted)
                .Select(x => new AppUserBloodTestValueViewModel
                {
                    AppUserBloodTestValueId = x.AppUserBloodTestValueId,
                    Value = x.Value,
                    CreateDate = x.CreateDate,
                }
                ).ToList();

            return list;
        }

        public void Delete(int appUserBloodTestValueId)
        {
            var appUserBloodTestValue = _context.AppUserBloodTestValues
                .Where(x => x.AppUserBloodTestValueId == appUserBloodTestValueId && !x.IsDeleted)
                .First();

            appUserBloodTestValue.IsDeleted = true;

            _context.SaveChanges();
        }

        public AppUserBloodTestValueViewModel Get(int appUserBloodTestValueId)
        {
            var item = _context.AppUserBloodTestValues
                .Where(x => x.AppUserBloodTestValueId == appUserBloodTestValueId && !x.IsDeleted)
                .Select(x => new AppUserBloodTestValueViewModel
                {
                    Value = x.Value,
                    CreateDate = x.CreateDate
                }).First();

            return item;

        }
    }
}