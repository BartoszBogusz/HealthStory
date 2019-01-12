using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HealthStory.Web.Entities
{
    public class SubDef
    {
        public SubDef()
        {
            BloodTestSubstances = new HashSet<BloodTestSubstance>();
        }
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Max { get; set; }
        public int Min { get; set; }
        public string Unit { get; set; }
        public ICollection<BloodTestSubstance> BloodTestSubstances { get; set; }

    }
}
