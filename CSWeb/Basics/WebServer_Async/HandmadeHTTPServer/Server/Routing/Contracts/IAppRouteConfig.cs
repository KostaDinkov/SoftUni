using System.Collections.Generic;
using HandmadeHTTPServer.Server.Enums;
using HandmadeHTTPServer.Server.Handlers;

namespace HandmadeHTTPServer.Server.Routing.Contracts
{
    public interface IAppRouteConfig
    {
        IReadOnlyDictionary<HttpRequestMethod, Dictionary<string, RequestHandler>> Routes { get; }

        void AddRoute(string route, RequestHandler httpHandler);
    }
}