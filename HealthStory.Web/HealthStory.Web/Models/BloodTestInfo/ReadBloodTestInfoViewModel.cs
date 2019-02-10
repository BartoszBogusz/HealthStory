using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthStory.Web.Models.BloodTestInfo
{
    public class ReadBloodTestInfoViewModel
    {
        public int BloodTestInfoId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int NumberOfSubstances { get; set; }
    }
}
