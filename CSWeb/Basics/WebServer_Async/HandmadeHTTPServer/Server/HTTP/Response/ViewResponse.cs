using HandmadeHTTPServer.Server.Enums;
using HandmadeHTTPServer.Server.HTTP.Contracts;

namespace HandmadeHTTPServer.Server.HTTP.Response
{
    public class ViewResponse:HttpResponse
    {
        public ViewResponse(IView view) : base()
        {
            this.View = view;
            this.StatusCode = HttpStatusCode.OK;
        }
    }
}