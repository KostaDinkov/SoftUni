using System.Collections.Generic;
using HandmadeHTTPServer.Server.Handlers;

namespace HandmadeHTTPServer.Server.Routing.Contracts
{
    public interface IRoutingContext
    {
        IEnumerable<string> Parameters { get; }
        RequestHandler RequestHandler { get; }
    }
}