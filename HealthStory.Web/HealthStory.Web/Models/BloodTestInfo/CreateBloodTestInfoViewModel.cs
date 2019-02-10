using HealthStory.Web.Models.SubstanceInfo;
using System.Collections.Generic;

namespace HealthStory.Web.Models.BloodTestInfo
{
    public class CreateBloodTestInfoViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<SubstanceInfoDto> Substances { get; set; }
    }
}
