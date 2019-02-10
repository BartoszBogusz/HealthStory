using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace HealthStory.Web.Models.SubstanceInfo
{
    public class SubstanceInfoCreateModel
    {
        public int SubstanceDefinitionId { get; set; }
        public string Name { get; set; }
        public decimal Max { get; set; }
        public decimal Min { get; set; }
        public string Unit { get; set; }
        public int UnitId { get; set; }
        public IEnumerable<SelectListItem> UnitSelectList { get; set; }
    }
}