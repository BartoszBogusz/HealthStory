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
        
        public virtual ICollection<AppUserBloodTestValue> AppUserBloodTestValue { get; set; }
    }
}
