using System;
using System.Collections.Generic;

namespace HealthStory.Web.Entities
{
    public class AppUser
    {
        public AppUser()
        {
            AppUserBloodTestValue = new HashSet<AppUserBloodTestValue>();
        }

        public int AppUserId { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime DateOfBirth { get; set; }

        public virtual ICollection<AppUserBloodTestValue> AppUserBloodTestValue { get; set; }
    }
}
