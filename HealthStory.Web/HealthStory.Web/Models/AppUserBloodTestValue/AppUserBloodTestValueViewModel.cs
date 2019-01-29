using System;

namespace HealthStory.Web.Models.AppUserBloodTestValue
{
    public class AppUserBloodTestValueViewModel
    {
        public int AppUserBloodTestValueId { get; set; }
        public int AppUserId { get; set; }
        public int SubstanceInfoId { get; set; }
        public int BloodTestInfoId { get; set; }
        public decimal Value { get; set; }
        public DateTime CreateDate { get; set; }
    }
}