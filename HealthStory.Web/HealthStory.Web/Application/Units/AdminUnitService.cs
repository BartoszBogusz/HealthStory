using HealthStory.Web.Entities;
using HealthStory.Web.Infrastructure;
using HealthStory.Web.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthStory.Web.Application.AdminUnits
{
    public interface IAdminUnitService
    {
        Task CreateAsync(AdminUnitsDto unit);
        Task<List<AdminUnitsDto>> GetAsync();
        Task<AdminUnitsDto> GetAsync(int unitId);
        Task UpdateAsync(AdminUnitsDto unit); 
        Task DeleteAsync(int unitId);
    }

    public class AdminUnitService : IAdminUnitService
    {
        private readonly HealthStoryContext _context;

        public AdminUnitService(HealthStoryContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(AdminUnitsDto unit)
        {
            var dbModel = new Unit
            {
                Name = unit.Name,
                Shortcut = unit.Shortcut
            };
            await _context.Units.AddAsync(dbModel);
            await _context.SaveChangesAsync();
        }

        public Task<List<AdminUnitsDto>> GetAsync()
        {
            var list = _context.Units
                .Where(x=> !x.IsDeleted)
                .Select(x => new AdminUnitsDto
            {
                UnitId = x.UnitId,
                Name = x.Name,
                Shortcut = x.Shortcut
            }).ToListAsync();

            return list;
        }

        public Task<AdminUnitsDto> GetAsync(int unitId)
        {
            var item = _context.Units
                .Where(x => x.UnitId == unitId && !x.IsDeleted)
                .Select(x => new AdminUnitsDto
                {
                    UnitId = x.UnitId,
                    Name = x.Name,
                    Shortcut = x.Shortcut
                }).FirstAsync();
            return item;
        }

        public async Task UpdateAsync(AdminUnitsDto unit)
        {
            var dbUnit = _context.Units
                .First(x => x.UnitId == unit.UnitId);

            dbUnit.Name = unit.Name;
            dbUnit.Shortcut = unit.Shortcut;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int unitId)
        {
            var unit = _context.Units
                .Where(x => x.UnitId == unitId && !x.IsDeleted).First();

            unit.IsDeleted = true;

            await _context.SaveChangesAsync();
        }
    }
}
