using System;
using System.Web.Mvc;
using Ninject;

namespace ProductDevelopment.Web.Infrastructure.Filters
{
    public class AdminOnly : FilterAttribute, IAuthorizationFilter 
    {
        [Inject]
        public IAuthentication Authentication { get; set; }

        public void OnAuthorization(AuthorizationContext filterContext)
        {
            var user = Authentication.CurrentUser();
            if(user == null || !user.Admin)
            {
                filterContext.Result = new HttpUnauthorizedResult("Get Off My Lawn!");
            }
        }
    }
}