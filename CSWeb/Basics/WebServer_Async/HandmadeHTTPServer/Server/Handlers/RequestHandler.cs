﻿using System;
using HandmadeHTTPServer.Server.Handlers.Contracts;
using HandmadeHTTPServer.Server.HTTP.Contracts;

namespace HandmadeHTTPServer.Server.Handlers
{
    public abstract class RequestHandler:IRequestHandler
    {
        private readonly Func<IHttpRequest, IHttpResponse> func;

        public RequestHandler(Func<IHttpRequest,IHttpResponse> func)
        {
            this.func = func;
        }
        public IHttpResponse Handle(IHttpContext httpContext)
        {
            IHttpResponse httpResponse = this.func(httpContext.Request);

            httpResponse.AddHeader("Content-Type", "text/html");
            return httpResponse;
        }
    }
}