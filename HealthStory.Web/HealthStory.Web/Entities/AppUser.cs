using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthStory.Web.Entities
{
    public class AppUser
    {
        public AppUser()
        {
            BloodTests = new HashSet<BloodTest>();
        }
        [Key]
        public int UserId { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ICollection<BloodTest> BloodTests { get; set; }
    }
}
