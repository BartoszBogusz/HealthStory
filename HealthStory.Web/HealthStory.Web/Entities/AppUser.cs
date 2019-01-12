using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HealthStory.Web.Entities
{
    public class AppUser
    {
        public AppUser()
        {
            BloodTests = new HashSet<BloodTest>();
        }

        public int AppUserId { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public virtual ICollection<BloodTest> BloodTests { get; set; }
    }
}
