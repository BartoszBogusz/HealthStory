using HealthStory.Web.Entities;
using HealthStory.Web.Infrastructure;
using HealthStory.Web.Models.SubstanceDefinition;
using System.Collections.Generic;
using System.Linq;

namespace HealthStory.Web.Application.AdminSubstance
{
    public interface IAdminSubstanceInfoService
    {
        void Create(SubstanceDefinitionCreateModel substance);
        List<SubstanceDefinitionReadViewModel> Get();
        SubstanceDefinitionReadViewModel Get(int substanceId);
    }
    public class AdminSubstanceInfoService : IAdminSubstanceInfoService
    {
        private readonly HealthStoryContext _context;

        public AdminSubstanceInfoService(HealthStoryContext context)
        {
            _context = context;
        }

        public void Create(SubstanceDefinitionCreateModel substance)
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

        public List<SubstanceDefinitionReadViewModel> Get()
        {
            var list = _context.SubstanceInfo.Select(x => new SubstanceDefinitionReadViewModel
            {
                Max = x.Max,
                Min = x.Min,
                Unit = x.Unit.Name,
                Name = x.Name
            }).ToList();
            return list;
        }

        public SubstanceDefinitionReadViewModel Get(int substanceId)
        {
            var list = _context.SubstanceInfo
                .Where(x => x.SubstanceInfoId == substanceId)
                .Select(x => new SubstanceDefinitionReadViewModel
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
