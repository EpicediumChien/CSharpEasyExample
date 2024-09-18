using Microsoft.Extensions.DependencyInjection;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using EasyExample.App_Start;
using System.Web.Services.Description;
using System.Web.Http;

namespace EasyExample
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            var services = new Microsoft.Extensions.DependencyInjection.ServiceCollection();
            ServiceConfig.RegisterServices(services);
            var serviceProvider = services.BuildServiceProvider();
            DependencyResolver.SetResolver(new DefaultDependencyResolver(serviceProvider));
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
