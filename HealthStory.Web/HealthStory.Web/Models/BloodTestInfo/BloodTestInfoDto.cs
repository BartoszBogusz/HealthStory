using HealthStory.Web.Models.SubstanceDefinition;
using System.Collections.Generic;

namespace HealthStory.Web.Models.BloodTestInfo
{
    public class BloodTestInfoDto
    {
        public int BloodTestId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<SubstanceInfoDto> Substances { get; set; }
    }
}
