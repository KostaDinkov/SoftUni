using System.Runtime.CompilerServices;
using HandmadeHTTPServer.Server.HTTP.Contracts;

namespace HandmadeHTTPServer.Server.HTTP
{
    public class HttpContext : IHttpContext
    {
        private readonly IHttpRequest request;


        public HttpContext(string requestStr)
        {
            this.request = new HttpRequest(requestStr);
        }

        public IHttpRequest Request => this.request;
    }
}