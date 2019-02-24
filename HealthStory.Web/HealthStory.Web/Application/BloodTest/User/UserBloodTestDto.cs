using System;
using System.Collections.Generic;

namespace HealthStory.Web.Application.BloodTest.User
{
    public class UserBloodTestDto
    {
        public int BloodTestId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; }
        public List<UserBloodTestSubstanceDto> Substances { get; set; }
    }
}
