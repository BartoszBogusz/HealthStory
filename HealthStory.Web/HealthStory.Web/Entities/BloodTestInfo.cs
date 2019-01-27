using System.Collections.Generic;

namespace HealthStory.Web.Entities
{
    public class BloodTestInfo
    {
        public BloodTestInfo()
        {
            BloodTestsSubstancesInfo = new HashSet<BloodTestSubstanceInfo>();
            AppUserBloodTestValue = new HashSet<AppUserBloodTestValue>();
        }
        public int BloodTestInfoId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<BloodTestSubstanceInfo> BloodTestsSubstancesInfo { get; set; }
        public virtual ICollection<AppUserBloodTestValue> AppUserBloodTestValue { get; set; }
    }
}