using HealthStory.Web.Entities;
using HealthStory.Web.Infrastructure;
using HealthStory.Web.Models.SubstanceInfo;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthStory.Web.Application.AdminSubstance
{
    public interface IAdminSubstanceInfoService
    {
        Task CreateAsync(SubstanceInfoCreateModel substance);
        Task<List<SubstanceInfoDto>> GetAsync();
        Task<List<SelectListItem>> GetSelectListItemsAsync();
        Task<SubstanceInfoCreateModel> GetAsync(int substanceId);
        Task UpdateAsync(SubstanceInfoCreateModel substance);
        Task DeleteAsync(int substanceId);
    }
    public class AdminSubstanceInfoService : IAdminSubstanceInfoService
    {
        private readonly HealthStoryContext _context;

        public AdminSubstanceInfoService(HealthStoryContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(SubstanceInfoCreateModel substance)
        {
            var newSubstance = new SubstanceInfo
            {
                Max = substance.Max,
                Min = substance.Min,
                Name = substance.Name,
                UnitId = substance.UnitId
            };
            await _context.SubstanceInfo.AddAsync(newSubstance);
            await _context.SaveChangesAsync();
        }

        public Task<List<SubstanceInfoDto>> GetAsync()
        {
            var list = _context.SubstanceInfo
                .Where(x => !x.IsDeleted)
                .Select(x => new SubstanceInfoDto
            {
                SubstanceInfoId = x.SubstanceInfoId,
                Max = x.Max,
                Min = x.Min,
                Unit = x.Unit.Name,
                Name = x.Name
            }).ToListAsync();
            return list;
        }

        public Task<SubstanceInfoCreateModel> GetAsync(int substanceId)
        {
            var item = _context.SubstanceInfo
                .Where(x => x.SubstanceInfoId == substanceId && !x.IsDeleted)
                .Select(x => new SubstanceInfoCreateModel
                {
                    SubstanceDefinitionId = x.SubstanceInfoId,
                    Name = x.Name,
                    Max = x.Max,
                    Min = x.Min,
                    UnitId = x.UnitId
                }).FirstAsync();
            return item;
        }

        public async Task UpdateAsync(SubstanceInfoCreateModel substance)
        {
            var dbSubstance = _context.SubstanceInfo
                .First(x => x.SubstanceInfoId == substance.SubstanceDefinitionId);

            dbSubstance.Max = substance.Max;
            dbSubstance.Min = substance.Min;
            dbSubstance.Name = substance.Name;
            dbSubstance.UnitId = substance.UnitId;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int substanceId)
        {
            var unit = _context.SubstanceInfo
                .Where(x => x.SubstanceInfoId == substanceId && !x.IsDeleted).First();

            unit.IsDeleted = true;

            await _context.SaveChangesAsync();
        }

        public Task<List<SelectListItem>> GetSelectListItemsAsync()
        {
            var substancesList = _context.SubstanceInfo
                .Where(x => !x.IsDeleted)
                .Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.SubstanceInfoId.ToString()
            }).ToListAsync();
            return substancesList;
        }
    }
}
