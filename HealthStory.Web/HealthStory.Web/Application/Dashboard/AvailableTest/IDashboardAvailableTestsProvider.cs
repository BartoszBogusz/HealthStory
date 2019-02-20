using HealthStory.Web.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthStory.Web.Application.Dashboard.AvailableTest
{
    public interface IDashboardAvailableTestsProvider
    {
        Task<List<DashboardBloodTestViewModel>> GetAsync();
    }

    public class DashboardAvailableTestsProvider : IDashboardAvailableTestsProvider
    {
        private readonly HealthStoryContext _context;

        public DashboardAvailableTestsProvider(HealthStoryContext context)
        {
            _context = context;
        }

        public Task<List<DashboardBloodTestViewModel>> GetAsync()
        {
            var list = _context.BloodTestsInfo
                .Where(x => !x.IsDeleted)
                .Select(x => new DashboardBloodTestViewModel
                {
                    BloodTestInfoId = x.BloodTestInfoId,
                    Name = x.Name
                }).ToListAsync();
            return list;
        }
    }
}
