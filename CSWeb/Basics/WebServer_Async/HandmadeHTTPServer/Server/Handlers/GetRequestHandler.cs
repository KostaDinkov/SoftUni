using System;

using HandmadeHTTPServer.Server.HTTP.Contracts;

namespace HandmadeHTTPServer.Server.Handlers
{
    public class GetRequestHandler:RequestHandler
    {
        public GetRequestHandler(Func<IHttpRequest, IHttpResponse> func) : base(func)
        {
        }
    }
}