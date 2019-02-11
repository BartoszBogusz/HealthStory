using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace HealthStory.Web.Entities
{
    public class AppUser : IdentityUser<string>
    {
        public AppUser()
        {
            AppUserBloodTestValue = new HashSet<AppUserBloodTestValue>();
        }

        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime DateOfBirth { get; set; }

        public virtual ICollection<AppUserBloodTestValue> AppUserBloodTestValue { get; set; }
    }
}
