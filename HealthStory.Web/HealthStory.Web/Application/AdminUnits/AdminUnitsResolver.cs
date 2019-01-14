using HealthStory.Web.Entities;
using HealthStory.Web.Infrastructure;
using HealthStory.Web.Models;

namespace HealthStory.Web.Application.AdminUnits
{
    public interface IAdminUnitsResolver
    {
        void AddUnit(AdminUnitsDto unit);
    }

    public class AdminUnitsResolver : IAdminUnitsResolver
    {
        private readonly HealthStoryContext _context;

        public AdminUnitsResolver(HealthStoryContext context)
        {
            _context = context;
        }

        public void AddUnit(AdminUnitsDto unit)
        {
            if (unit.Name == null)
                return;

            if (unit.Shortcut == null)
                return;

            var newUnit = new Unit
            {
                Name = unit.Name,
                Shortcut = unit.Shortcut,
            };

            _context.Units.Add(newUnit);
            _context.SaveChanges();
        }

       
    }
}
