using HandmadeHTTPServer.Application.Views;
using HandmadeHTTPServer.Server.HTTP.Contracts;
using HandmadeHTTPServer.Server.HTTP.Response;

namespace HandmadeHTTPServer.Application.Controllers
{
    public class HomeController
    {
        public IHttpResponse Index()
        {
            return new ViewResponse(new HomeIndexView());
        }
    }
}