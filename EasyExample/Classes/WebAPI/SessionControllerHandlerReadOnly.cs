using System.Web.Http.WebHost;
using System.Web.Routing;
using System.Web.SessionState;

namespace EasyExample.Classes.WebAPI
{
    public class SessionControllerHandlerReadOnly : HttpControllerHandler, IReadOnlySessionState
    {
        public SessionControllerHandlerReadOnly(RouteData routeData)
            : base(routeData)
        { }
    }
}