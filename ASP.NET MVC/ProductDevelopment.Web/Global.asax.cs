using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using ProductDevelopment.Models;
using ProductDevelopment.Web.Infrastructure;
using ProductDevelopment.Web.Infrastructure.Data;
using ProductDevelopment.Web.Infrastructure.Security;
using ProductDevelopment.Web.Models;

namespace ProductDevelopment.Web
{
    public class MvcApplication : HttpApplication
    {
        private static IKernel _kernel;

        protected void Application_Start()
        {
            Database.SetInitializer(new SeedData()); //Do not include in release/production

            AreaRegistration.RegisterAllAreas();
            RegisterDependencyResolver();
            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }

        private static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(_kernel.TryGet(typeof(UserProviderFilterAttribute)));
        }

        private static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new {controller = "Home", action = "Index", id = UrlParameter.Optional} // Parameter defaults
                );
        }

        private static void RegisterDependencyResolver()
        {
            _kernel = new StandardKernel();
            _kernel.Bind<IAuthentication>().To<Authentication>().InRequestScope();
            _kernel.Bind<IUserRepository>().To<UserRepository>().InRequestScope();
            _kernel.Bind<IRepository<Defect>>().To<Repository<Defect>>().InRequestScope();
            _kernel.Bind<IRepository<Project>>().To<Repository<Project>>().InRequestScope();
            _kernel.Bind<IRepository<Severity>>().To<Repository<Severity>>().InRequestScope();
            _kernel.Bind<UserProviderFilterAttribute>().To<UserProviderFilterAttribute>().InRequestScope();
            DependencyResolver.SetResolver(new NinjectDependencyResolver(_kernel));
        }
    }
}