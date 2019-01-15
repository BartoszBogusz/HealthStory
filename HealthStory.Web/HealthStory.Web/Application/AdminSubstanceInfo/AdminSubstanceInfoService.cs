using HealthStory.Web.Entities;
using HealthStory.Web.Infrastructure;
using HealthStory.Web.Models.SubstanceDefinition;

namespace HealthStory.Web.Application.AdminSubstance
{
    public interface IAdminSubstanceInfoService
    {
        void Create(SubstanceDefinitionCreateModel substance);
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
                Name = substance.Name //TODO Unit
            };
            _context.SubstanceInfo.Add(newSubstance);
            _context.SaveChanges();
        }
    }
}
