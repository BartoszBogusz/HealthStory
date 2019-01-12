using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HealthStory.Web.Entities
{
    public class BloodTestSubstance
    {
        [Key]
        public int BloodTestSubstanceId { get; set; }
        public int Value { get; set; }
        public virtual BloodTest BloodTest { get; set; }
        public virtual SubDef SubDef { get; set; }
    }
}
