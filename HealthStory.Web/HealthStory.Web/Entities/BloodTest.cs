using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HealthStory.Web.Entities
{
    public class BloodTest
    {
        public BloodTest()
        {
            BloodTestSubstances = new HashSet<BloodTestSubstance>();          
        }
        [Key]
        public int BloodTestId { get; set; }
        public int? UserId { get; set; }
        public virtual AppUser AppUser { get; set; }
        public DateTime Date { get; set; }       
        public ICollection<BloodTestSubstance> BloodTestSubstances { get; set; }
    }
}
