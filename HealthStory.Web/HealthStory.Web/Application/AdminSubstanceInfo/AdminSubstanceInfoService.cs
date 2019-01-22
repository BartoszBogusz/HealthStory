using HealthStory.Web.Entities;
using HealthStory.Web.Infrastructure;
using HealthStory.Web.Models.SubstanceDefinition;
using System.Collections.Generic;
using System.Linq;

namespace HealthStory.Web.Application.AdminSubstance
{
    public interface IAdminSubstanceInfoService
    {
        void Create(SubstanceInfoCreateModel substance);
        List<SubstanceInfoReadViewModel> Get();
        SubstanceInfoReadViewModel Get(int substanceId);
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

        public List<SubstanceInfoReadViewModel> Get()
        {
            var list = _context.SubstanceInfo
                .Where(x=> !x.IsDeleted)
                .Select(x => new SubstanceInfoReadViewModel
            {
                SubstanceInfoId = x.SubstanceInfoId,
                Max = x.Max,
                Min = x.Min,
                Unit = x.Unit.Name,
                Name = x.Name
            }).ToList();
            return list;
        }

        public SubstanceInfoReadViewModel Get(int substanceId)
        {
            var list = _context.SubstanceInfo
                .Where(x => x.SubstanceInfoId == substanceId && !x.IsDeleted)
                .Select(x => new SubstanceInfoReadViewModel
                {
                    SubstanceInfoId = x.SubstanceInfoId,
                    Max = x.Max,
                    Min = x.Min,
                    Unit = x.Unit.Name,
                    Name = x.Name
                }).First();
            return list;
        }

        public void Delete(int substanceId)
        {
            var unit = _context.SubstanceInfo.Where(x => x.SubstanceInfoId == substanceId).First();

            unit.IsDeleted = true;

            _context.SaveChanges();
        }


    }
}
