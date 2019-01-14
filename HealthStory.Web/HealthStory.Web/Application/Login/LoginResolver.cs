using HealthStory.Web.Entities;
using HealthStory.Web.Infrastructure;
using HealthStory.Web.Models;
using System.Linq;


namespace HealthStory.Web.Application.Login
{
    public interface ILoginResolver
    {
        bool Login(UserLoginDto user);
    }

    public class LoginResolver : ILoginResolver
    {
        private readonly HealthStoryContext _context;

        public LoginResolver(HealthStoryContext context)
        {
            _context = context;
        }

        public bool Login(UserLoginDto user)
        {
            if (user.LoginOrEmail == null || user.Password == null)
            {
                return false;
            }
            
            var areCredentialsCorrect = (from a in _context.AppUsers
                                         where a.Password == user.Password &&
                                         (a.Email == user.LoginOrEmail || a.Login == user.LoginOrEmail)
                                         select a).Any();

            return areCredentialsCorrect;
        }     
    }
}
