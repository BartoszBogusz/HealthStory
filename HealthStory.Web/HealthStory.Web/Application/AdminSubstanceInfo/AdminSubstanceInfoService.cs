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
            var list = _context.SubstanceInfo.Select(x => new SubstanceInfoReadViewModel
            {
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
                .Where(x => x.SubstanceInfoId == substanceId)
                .Select(x => new SubstanceInfoReadViewModel
                {
                    Max = x.Max,
                    Min = x.Min,
                    Unit = x.Unit.Name,
                    Name = x.Name
                }).First();
            return list;
        }
    }
}
