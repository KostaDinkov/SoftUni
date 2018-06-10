using System.Collections.Generic;
using HandmadeHTTPServer.Server.Handlers;
using HandmadeHTTPServer.Server.Routing.Contracts;

namespace HandmadeHTTPServer.Server.Routing
{
    public class RoutingContext : IRoutingContext
    {
        public RoutingContext(RequestHandler requestHandler, IEnumerable<string> parameters)
        {
            this.Parameters = parameters;
            this.RequestHandler = requestHandler;
        }

        public IEnumerable<string> Parameters { get; }
        public RequestHandler RequestHandler { get; }
    }
}