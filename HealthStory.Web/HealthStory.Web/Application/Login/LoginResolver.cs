using HealthStory.Web.Entities;
using HealthStory.Web.Infrastructure;
using HealthStory.Web.Models;
using System.Linq;


namespace HealthStory.Web.Application.Login
{
    public interface ILoginResolver
    {
        void Login(UserLoginDto user);
    }

    public class LoginResolver : ILoginResolver
    {
        private readonly HealthStoryContext _context;

        public LoginResolver(HealthStoryContext context)
        {
            _context = context;
        }

        public void Login(UserLoginDto user)
        {
            if (user.LoginOrEmail == null || user.Password == null)
            {
                return;
            }
            
            
            var areCredentialsCorrect = (from a in _context.AppUsers
                                         where a.Password == user.Password &&
                                         (a.Email == user.LoginOrEmail || a.Login == user.LoginOrEmail)
                                         select a).Any();
            if (areCredentialsCorrect)
            {
                user.RulesAcceptation = true;
            }
            else
            {
                user.RulesAcceptation = true;
            }

            //_context.SaveChanges();

        }
    }
}
