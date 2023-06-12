using System.Web.Http.WebHost;
using System.Web.Routing;
using System.Web.SessionState;

namespace WebApplication2.Classes.WebAPI
{
    public class SessionControllerHandlerReadOnly : HttpControllerHandler, IReadOnlySessionState
    {
        public SessionControllerHandlerReadOnly(RouteData routeData)
            : base(routeData)
        { }
    }
}