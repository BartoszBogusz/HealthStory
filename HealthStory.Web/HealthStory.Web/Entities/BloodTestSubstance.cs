using System.ComponentModel.DataAnnotations;

namespace HealthStory.Web.Entities
{
    public class BloodTestSubstance
    {
        public int BloodTestSubstanceId { get; set; }
        public int Value { get; set; }
        public int BloodTestId { get; set; }
        public int SubstanceInfoId { get; set; }

        public virtual BloodTest BloodTest { get; set; }
        public virtual SubstanceInfo SubstanceInfo { get; set; }
    }
}
