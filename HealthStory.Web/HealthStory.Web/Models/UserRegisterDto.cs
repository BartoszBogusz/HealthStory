using System;

namespace HealthStory.Web.Models
{
    public class UserRegisterDto
    {
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public bool RulesAcceptation { get; set; }
    }
}