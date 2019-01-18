namespace HealthStory.Web.Models.SubstanceDefinition
{
    public class SubstanceInfoReadViewModel
    {
        public int SubstanceInfoId { get; set; }
        public string Name { get; set; }
        public decimal Max { get; set; }
        public decimal Min { get; set; }
        public string Unit { get; set; }
    }
}