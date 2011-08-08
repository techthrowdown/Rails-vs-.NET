using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using ProductDevelopment.Models;
using ProductDevelopment.Repository;

namespace ProductDevelopment.Web.Infrastructure
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
            if(_userRepository.ValidateUserCredentials(username, password))
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

        public User CurrentUser()
        {
            var ctx = HttpContext.Current;
            if(ctx.Request.IsAuthenticated)
            {
                var user = ctx.Items["CurrentUser"] as User;
                if(user == null)
                {
                    user = _userRepository.FindByUsername(ctx.User.Identity.Name);
                }
                return user;
            }
            return null;
        }
    }

    public interface IAuthentication
    {
        bool LogonUser(string username, string password, bool persistLogin);
        void LogoutUser();
        User CurrentUser();
    }
}