namespace HealthStory.Web.Entities
{
    public class BloodTestSubstanceInfo
    {
        public int BloodTestInfoId { get; set; }
        public int SubstanceInfoId { get; set; }
        public bool IsDeleted { get; set; }

        public virtual BloodTestInfo BloodTestsInfo { get; set; }
        public virtual SubstanceInfo SubstanceInfo { get; set; }
    }
}
