using HealthStory.Web.Infrastructure;
using System.Collections.Generic;
using System.Linq;

namespace HealthStory.Web.Application.Dashboard.AvailableTest
{
    public interface IDashboardAvailableTestsProvider
    {
        List<ReadBloodTestInfoViewModel> Get();
    }

    public class DashboardAvailableTestsProvider : IDashboardAvailableTestsProvider
    {
        private readonly HealthStoryContext _context;

        public DashboardAvailableTestsProvider(HealthStoryContext context)
        {
            _context = context;
        }

        public List<ReadBloodTestInfoViewModel> Get()
        {
            var list = _context.BloodTestsInfo
                .Where(x => !x.IsDeleted)
                .Select(x => new ReadBloodTestInfoViewModel
                {
                    BloodTestInfoId = x.BloodTestInfoId,
                    Name = x.Name
                }).ToList();
            return list;
        }
    }
}
