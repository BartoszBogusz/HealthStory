using System;

namespace HealthStory.Web.Entities
{
    public class AppUserBloodTestValue
    {
        public int AppUserBloodTestValueId { get; set; }
        public string AppUserId { get; set; }
        public int SubstanceInfoId { get; set; }
        public int BloodTestInfoId { get; set; }
        public decimal Value { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsDeleted { get; set; }

        public virtual AppUser AppUser { get; set; }
        public virtual SubstanceInfo SubstanceInfo { get; set; }
        public virtual BloodTestInfo BloodTestInfo { get; set; }
    }
}
