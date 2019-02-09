using HealthStory.Web.Entities;
using HealthStory.Web.Infrastructure;
using HealthStory.Web.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace HealthStory.Web.Application.AdminUnits
{
    public interface IAdminUnitService
    {
        void Create(AdminUnitsDto unit);
        List<AdminUnitsDto> Get();
        AdminUnitsDto Get(int unitId);
        void Update(AdminUnitsDto unit); 
        void Delete(int unitId);
    }

    public class AdminUnitService : IAdminUnitService
    {
        private readonly HealthStoryContext _context;

        public AdminUnitService(HealthStoryContext context)
        {
            _context = context;
        }

        public void Create(AdminUnitsDto unit)
        {
            var dbModel = new Unit
            {
                Name = unit.Name,
                Shortcut = unit.Shortcut
            };
            _context.Units.Add(dbModel);
            _context.SaveChanges();
        }

        public List<AdminUnitsDto> Get()
        {
            var list = _context.Units
                .Where(x=> !x.IsDeleted)
                .Select(x => new AdminUnitsDto
            {
                UnitId = x.UnitId,
                Name = x.Name,
                Shortcut = x.Shortcut
            }).ToList();
            return list;
        }

        public AdminUnitsDto Get(int unitId)
        {
            var item = _context.Units
                .Where(x => x.UnitId == unitId && !x.IsDeleted)
                .Select(x => new AdminUnitsDto
                {
                    UnitId = x.UnitId,
                    Name = x.Name,
                    Shortcut = x.Shortcut
                }).First();
            return item;
        }

        public void Update(AdminUnitsDto unit)
        {
            var dbUnit = _context.Units
                .First(x => x.UnitId == unit.UnitId);

            dbUnit.Name = unit.Name;
            dbUnit.Shortcut = unit.Shortcut;

            _context.SaveChanges();
        }

        public void Delete(int unitId)
        {
            var unit = _context.Units
                .Where(x => x.UnitId == unitId && !x.IsDeleted).First();

            unit.IsDeleted = true;

            _context.SaveChanges();
        }
    }
}
