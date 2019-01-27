using System.Collections.Generic;

namespace HealthStory.Web.Entities
{
    public class SubstanceInfo
    {
        public SubstanceInfo()
        {
            BloodTestsSubstancesInfo = new HashSet<BloodTestSubstanceInfo>();
            AppUserBloodTestValue = new HashSet<AppUserBloodTestValue>();
        }
        
        public int SubstanceInfoId { get; set; }
        public string Name { get; set; }
        public decimal Max { get; set; }
        public decimal Min { get; set; }
        public int UnitId { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Unit Unit { get; set; }
        public virtual ICollection<BloodTestSubstanceInfo> BloodTestsSubstancesInfo { get; set; }
        public virtual ICollection<AppUserBloodTestValue> AppUserBloodTestValue { get; set; }
    }
}
