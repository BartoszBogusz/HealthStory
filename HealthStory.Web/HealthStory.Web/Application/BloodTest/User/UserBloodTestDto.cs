using System.Collections.Generic;
using System.Linq;
using HealthStory.Web.Models.BloodTestInfo;

namespace HealthStory.Web.Application.BloodTest.User
{
    public class UserBloodTestDto
    {
        public UserBloodTestDto(BloodTestInfoDto bloodTestInfoDto)
        {
            BloodTestId = bloodTestInfoDto.BloodTestId;
            Name = bloodTestInfoDto.Name;
            Description = bloodTestInfoDto.Description;
            Substances = bloodTestInfoDto.Substances
                .Select(x => new UserBloodTestSubstanceDto(x.SubstanceInfoId, x.Name,0))
                .ToList();
        }
        public int BloodTestId { get; }
        public string Name { get; }
        public string Description { get; }
        public List<UserBloodTestSubstanceDto> Substances { get; }
    }
}
