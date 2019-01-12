using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HealthStory.Web.Entities
{
    public class BloodTest
    {
        public BloodTest()
        {
            BloodTestSubstances = new HashSet<BloodTestSubstance>();          
        }

        public int BloodTestId { get; set; }
        public DateTime Date { get; set; }
        public int AppUserId { get; set; }

        public virtual AppUser AppUser { get; set; }
        public virtual ICollection<BloodTestSubstance> BloodTestSubstances { get; set; }
    }
}
