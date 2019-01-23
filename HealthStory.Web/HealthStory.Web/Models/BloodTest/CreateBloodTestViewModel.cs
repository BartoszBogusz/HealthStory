﻿using HealthStory.Web.Models.SubstanceDefinition;
using System.Collections.Generic;

namespace HealthStory.Web.Models.BloodTest
{
    public class CreateBloodTestViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<SubstanceInfoDto> Substances { get; set; }
    }
}
