using System.Collections.Generic;

namespace HealthStory.Web.Entities
{
    public class SubstanceInfo
    {
        public SubstanceInfo()
        {
            BloodTestSubstances = new HashSet<BloodTestSubstance>();
        }
        
        public int SubstanceInfoId { get; set; }
        public string Name { get; set; }
        public decimal Max { get; set; }
        public decimal Min { get; set; }
        public int UnitId { get; set; }

        public virtual Unit Unit { get; set; }
        public virtual ICollection<BloodTestSubstance> BloodTestSubstances { get; set; }

    }
}
