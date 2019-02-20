using HealthStory.Web.Infrastructure;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthStory.Web.Application.Units.SelectList
{
    public interface IUnitSelectListProvider
    {
        Task<List<SelectListItem>> GetAsync();
    }

    public class UnitSelectListProvider : IUnitSelectListProvider
    {
        private readonly HealthStoryContext _context;

        public UnitSelectListProvider(HealthStoryContext context)
        {
            _context = context;
        }

        public Task<List<SelectListItem>> GetAsync()
        {
            var list = _context.Units.Select(x => new SelectListItem
            {
                Text = x.Name.ToString(),
                Value = x.UnitId.ToString()
            }).ToListAsync();
            return list;
        }
    }
}
