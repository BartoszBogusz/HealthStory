using HealthStory.Web.Entities;
using HealthStory.Web.Infrastructure;
using HealthStory.Web.Models.SubstanceInfo;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace HealthStory.Web.Application.AdminSubstance
{
    public interface IAdminSubstanceInfoService
    {
        void Create(SubstanceInfoCreateModel substance);
        List<SubstanceInfoDto> Get();
        List<SelectListItem> GetSelectListItems();
        SubstanceInfoCreateModel Get(int substanceId);
        void Update(SubstanceInfoCreateModel substance);
        void Delete(int substanceId);
    }
    public class AdminSubstanceInfoService : IAdminSubstanceInfoService
    {
        private readonly HealthStoryContext _context;

        public AdminSubstanceInfoService(HealthStoryContext context)
        {
            _context = context;
        }

        public void Create(SubstanceInfoCreateModel substance)
        {
            var newSubstance = new SubstanceInfo
            {
                Max = substance.Max,
                Min = substance.Min,
                Name = substance.Name,
                UnitId = substance.UnitId
            };
            _context.SubstanceInfo.Add(newSubstance);
            _context.SaveChanges();
        }

        public List<SubstanceInfoDto> Get()
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
            }).ToList();
            return list;
        }

        public SubstanceInfoCreateModel Get(int substanceId)
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
                }).First();
            return item;
        }

        public void Update(SubstanceInfoCreateModel substance)
        {
            var dbSubstance = _context.SubstanceInfo
                .First(x => x.SubstanceInfoId == substance.SubstanceDefinitionId);

            dbSubstance.Max = substance.Max;
            dbSubstance.Min = substance.Min;
            dbSubstance.Name = substance.Name;
            dbSubstance.UnitId = substance.UnitId;

            _context.SaveChanges();
        }

        public void Delete(int substanceId)
        {
            var unit = _context.SubstanceInfo
                .Where(x => x.SubstanceInfoId == substanceId && !x.IsDeleted).First();

            unit.IsDeleted = true;

            _context.SaveChanges();
        }

        public List<SelectListItem> GetSelectListItems()
        {
            var substancesList = _context.SubstanceInfo.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.SubstanceInfoId.ToString()
            }).ToList();
            return substancesList;
        }
    }
}
