using System.Web.Http;
using System.Web.Routing;
using EasyExample.Classes.WebAPI;
using static Org.BouncyCastle.Math.EC.ECCurve;

namespace EasyExample.App_Start
{
    public class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}