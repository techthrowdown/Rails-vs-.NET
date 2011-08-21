using System.Web;
using System.Web.Security;
using ProductDevelopment.Web.Infrastructure.Data;
using ProductDevelopment.Web.Models;

namespace ProductDevelopment.Web.Infrastructure.Security
{
    public class Authentication : IAuthentication
    {
        private readonly IUserRepository _userRepository;

        public Authentication(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool LogonUser(string username, string password, bool persistLogin)
        {
            if (_userRepository.ValidateUserCredentials(username, password))
            {
                FormsAuthentication.SetAuthCookie(username, persistLogin);
                return true;
            }
            return false;
        }

        public void LogoutUser()
        {
            FormsAuthentication.SignOut();
        }

        public UserToken CurrentUser()
        {
            var ctx = HttpContext.Current;
            if (ctx.Request.IsAuthenticated)
            {
                var userToken = ctx.Items["CurrentUser"] as UserToken;
                if (userToken == null)
                {
                    var user = _userRepository.FindByUsername(ctx.User.Identity.Name);
                    userToken = new UserToken()
                    {
                        Admin = user.Admin,
                        Authenticated = true,
                        UserId = user.UserId,
                        Username = user.Username
                    };
                    ctx.Items["CurrentUser"] = userToken;
                }
                return userToken;
            }
            return null;
        }
    }
}