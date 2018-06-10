using HandmadeHTTPServer.Application.Controllers;
using HandmadeHTTPServer.Server.Contracts;
using HandmadeHTTPServer.Server.Handlers;

using HandmadeHTTPServer.Server.Routing.Contracts;

namespace HandmadeHTTPServer.Application
{
    public class MainApplication:IApplication
    {
        public void Start(IAppRouteConfig routeConfig)
        {
            routeConfig.AddRoute("/", new GetRequestHandler(httpContext=> new HomeController().Index()));
        }
    }
}