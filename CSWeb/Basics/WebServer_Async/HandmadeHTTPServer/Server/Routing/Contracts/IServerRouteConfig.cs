using System.Collections.Generic;
using HandmadeHTTPServer.Server.Enums;

namespace HandmadeHTTPServer.Server.Routing.Contracts
{
    public interface IServerRouteConfig
    {
        Dictionary<HttpRequestMethod, Dictionary<string, IRoutingContext>> Routes { get; }
    }
}