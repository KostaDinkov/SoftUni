using HandmadeHTTPServer.Server.HTTP.Contracts;

namespace HandmadeHTTPServer.Server.Handlers.Contracts
{
    public interface IRequestHandler
    {
        IHttpResponse Handle(IHttpContext httpContext);
    }
}