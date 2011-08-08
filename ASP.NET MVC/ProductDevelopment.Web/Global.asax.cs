using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using ProductDevelopment.Models;
using ProductDevelopment.Repository;
using ProductDevelopment.Web.Infrastructure;

namespace ProductDevelopment.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        private IKernel kernel; 
        protected void Application_Start()
        {
            kernel = new StandardKernel();
            
            Database.SetInitializer(new SeedData());  //Do not include in release/production

            AreaRegistration.RegisterAllAreas();
            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
            RegisterDependencyResolver(kernel);
            FilterProviders.Providers.Add(new InjectableFilterProvider(kernel));
        }

        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );
        }

        private static void RegisterDependencyResolver(IKernel kernel)
        {
            kernel.Bind<IProductDevelopmentContext>().To<ProductDevelopmentContext>().InRequestScope();
            kernel.Bind<IUserRepository>().To<UserRepository>().InRequestScope();
            kernel.Bind<IAuthentication>().To<Authentication>().InRequestScope();
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }
}