using System.Web.Http;
using System.Web.Routing;
using WebApplication2.Classes.WebAPI;

namespace WebApplication2.App_Start
{
    public class WebApiConfig
    {
        public static void RegisterWebAPI(RouteCollection routes)
        {
            routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}",
                defaults: new { action = RouteParameter.Optional }).RouteHandler = new SessionRouteHandlerReadOnly();
        }
    }
}