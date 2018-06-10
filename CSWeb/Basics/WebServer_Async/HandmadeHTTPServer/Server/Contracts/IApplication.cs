using HandmadeHTTPServer.Server.Routing.Contracts;

namespace HandmadeHTTPServer.Server.Contracts
{
    public interface IApplication
    {
        void Start(IAppRouteConfig routeConfig);
    }
}