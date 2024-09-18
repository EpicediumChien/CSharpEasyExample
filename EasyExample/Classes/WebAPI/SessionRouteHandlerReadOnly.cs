using System.Web;
using System.Web.Routing;

namespace EasyExample.Classes.WebAPI
{
    public class SessionRouteHandlerReadOnly : IRouteHandler
    {
        IHttpHandler IRouteHandler.GetHttpHandler(RequestContext requestContext)
        {
            return new SessionControllerHandlerReadOnly(requestContext.RouteData);
        }
    }
}