using HealthStory.Web.Entities;
using HealthStory.Web.Infrastructure;
using HealthStory.Web.Models;

namespace HealthStory.Web.Application.Register
{
    public interface IRegisterResolver
    {
        void Register(UserRegisterDto user);
    }

    public class RegisterResolver : IRegisterResolver
    {
        private readonly HealthStoryContext _context;

        public RegisterResolver(HealthStoryContext context)
        {
            _context = context;
        }

        public void Register(UserRegisterDto user)
        {
            if (user.Password != user.ConfirmPassword)
                return;

            var newUser = new AppUser
            {
                Email = user.Email,
                Login = user.Login,
                Password = user.Password
            };

            _context.AppUsers.Add(newUser);
            _context.SaveChanges();
        }
    }
}
