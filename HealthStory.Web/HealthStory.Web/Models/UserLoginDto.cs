using System;

namespace HealthStory.Web.Models
{
    public class UserLoginDto
    {
        public string LoginOrEmail { get; set; }
        public string Password { get; set; }
        public bool RulesAcceptation { get; set; }
    }
}