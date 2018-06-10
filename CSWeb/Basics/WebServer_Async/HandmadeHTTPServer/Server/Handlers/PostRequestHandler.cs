using System;
using HandmadeHTTPServer.Server.HTTP.Contracts;

namespace HandmadeHTTPServer.Server.Handlers
{
    public class PostRequestHandler:RequestHandler
    {
        public PostRequestHandler(Func<IHttpRequest, IHttpResponse> func) : base(func)
        {
        }
    }
}