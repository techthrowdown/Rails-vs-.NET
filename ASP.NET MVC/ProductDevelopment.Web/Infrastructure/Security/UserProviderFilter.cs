using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using ProductDevelopment.Web.Models;

namespace ProductDevelopment.Web.Infrastructure.Security
{
    public class UserProviderFilterAttribute : IAuthorizationFilter
    {
        private readonly IAuthentication _authentication;

        public UserProviderFilterAttribute(IAuthentication authentication)
        {
            _authentication = authentication;
        }

        public void OnAuthorization(AuthorizationContext filterContext)
        {
            var user = _authentication.CurrentUser() ?? new UserToken()
            {
                Admin = false,
                Authenticated = false
            };
            filterContext.Controller.ViewBag.User = user;
        }
    }
}