using System;
using System.Collections.Generic;

namespace HealthStory.Web.Entities
{
    public class Unit
    {
        public Unit()
        {
            SubstanceInfo = new HashSet<SubstanceInfo>();
        }

        public int UnitId { get; set; }
        public string Name { get; set; }
        public string Shortcut { get; set; }

        public virtual ICollection<SubstanceInfo> SubstanceInfo { get; set; }
    }
}
