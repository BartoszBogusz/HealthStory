using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace HealthStory.Web.Models.SubstanceDefinition
{
    public class SubstanceDefinitionReadModel
    {
        public string Name { get; set; }
        public decimal Max { get; set; }
        public decimal Min { get; set; }
        public string Unit { get; set; }
    }
}