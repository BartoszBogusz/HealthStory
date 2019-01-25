using System;

namespace HealthStory.Web.Entities
{
    public class AppUser
    {
        public int AppUserId { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
