namespace HealthStory.Web.Application.BloodTest.User
{
    public class UserBloodTestSubstanceDto
    {
        public UserBloodTestSubstanceDto(int substanceInfoId, string name, decimal value)
        {
            SubstanceInfoId = substanceInfoId;
            Name = name;
            Value = value;
        }

        public int SubstanceInfoId { get; }
        public string Name { get; }
        public decimal Value { get; }
    }
}