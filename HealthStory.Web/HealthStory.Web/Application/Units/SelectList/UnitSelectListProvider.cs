using HealthStory.Web.Infrastructure;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace HealthStory.Web.Application.Units.SelectList
{
    public interface IUnitSelectListProvider
    {
        List<SelectListItem> Get();
    }

    public class UnitSelectListProvider : IUnitSelectListProvider
    {
        private readonly HealthStoryContext _context;

        public UnitSelectListProvider(HealthStoryContext context)
        {
            _context = context;
        }

        public List<SelectListItem> Get()
        {
            var list = _context.Units.Select(x => new SelectListItem
            {
                Text = x.Name.ToString(),
                Value = x.UnitId.ToString()
            }).ToList();
            return list;
        }
    }
}
