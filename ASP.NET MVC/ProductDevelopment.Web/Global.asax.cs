using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using ProductDevelopment.Models;
using ProductDevelopment.Repository;
using ProductDevelopment.Web.Infrastructure;

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
            FilterProviders.Providers.Add(new InjectableFilterProvider(kernel));
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
            kernel.Bind<IUserRepository>().To<UserRepository>().InRequestScope();
            kernel.Bind<IAuthentication>().To<Authentication>().InRequestScope();
            kernel.Bind<IRepository<Defect>>().To<Repository<Defect>>().InRequestScope();
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }
}