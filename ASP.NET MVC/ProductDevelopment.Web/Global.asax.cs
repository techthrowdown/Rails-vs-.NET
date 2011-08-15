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
        protected void Application_Start()
        {
            var kernel = new StandardKernel();

            Database.SetInitializer(new SeedData()); //Do not include in release/production

            AreaRegistration.RegisterAllAreas();
            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
            RegisterDependencyResolver(kernel);
        }

        private static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
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

        private static void RegisterDependencyResolver(IKernel kernel)
        {
            kernel.Bind<IAuthentication>().To<Authentication>().InRequestScope();
            kernel.Bind<IUserRepository>().To<UserRepository>().InRequestScope();
            kernel.Bind<IRepository<Defect>>().To<Repository<Defect>>().InRequestScope();
            kernel.Bind<IRepository<Project>>().To<Repository<Project>>().InRequestScope();
            kernel.Bind<IRepository<Severity>>().To<Repository<Severity>>().InRequestScope();
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }
}