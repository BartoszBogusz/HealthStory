using HealthStory.Web.Infrastructure;
using System.Collections.Generic;
using System.Linq;

namespace HealthStory.Web.Application.Dashboard.AvailableTest
{
    public interface IDashboardAvailableTestsProvider
    {
        List<DashboardBloodTestViewModel> Get();
    }

    public class DashboardAvailableTestsProvider : IDashboardAvailableTestsProvider
    {
        private readonly HealthStoryContext _context;

        public DashboardAvailableTestsProvider(HealthStoryContext context)
        {
            _context = context;
        }

        public List<DashboardBloodTestViewModel> Get()
        {
            var list = _context.BloodTestsInfo
                .Where(x => !x.IsDeleted)
                .Select(x => new DashboardBloodTestViewModel
                {
                    BloodTestInfoId = x.BloodTestInfoId,
                    Name = x.Name
                }).ToList();
            return list;
        }
    }
}
