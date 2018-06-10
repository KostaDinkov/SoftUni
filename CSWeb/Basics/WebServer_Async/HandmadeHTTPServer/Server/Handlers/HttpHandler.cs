
using System.Text.RegularExpressions;
using HandmadeHTTPServer.Server.Handlers.Contracts;
using HandmadeHTTPServer.Server.HTTP.Contracts;
using HandmadeHTTPServer.Server.HTTP.Response;
using HandmadeHTTPServer.Server.Routing.Contracts;

namespace HandmadeHTTPServer.Server.Handlers
{
    public class HttpHandler:IRequestHandler
    {
        private readonly IServerRouteConfig serverRouteConfig;

        public HttpHandler(IServerRouteConfig serverRouteConfig)
        {
            this.serverRouteConfig = serverRouteConfig;
        }
        public IHttpResponse Handle(IHttpContext httpContext)
        {
            foreach (var routingContext in this.serverRouteConfig.Routes[httpContext.Request.RequestMethod])
            {
                string pattern = routingContext.Key;
                
                Regex regex = new Regex(pattern);
                Match match = regex.Match(httpContext.Request.Path);

                if (!match.Success)
                {
                    continue;
                }

                foreach (var parameter in routingContext.Value.Parameters)
                {
                    httpContext.Request.AddUrlParameter(parameter, match.Groups[parameter].Value);
                }

                
                return routingContext.Value.RequestHandler.Handle(httpContext);
            }
            
            return new NotFoundResponse();
           
        }
    }
}