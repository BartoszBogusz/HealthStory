using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace HealthStory.Web.Models.SubstanceDefinition
{
    public class SubstanceDefinitionCreateModel
    {
        public int SubstanceDefinitionId { get; set; }
        public string Name { get; set; }
        public decimal Max { get; set; }
        public decimal Min { get; set; }
        public int UnitId { get; set; }
        public IEnumerable<SelectListItem> UnitSelectList { get; set; }
    }
}