using System;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using SUS.HTTP;

namespace FirstMvcApps
{
    class Program
    {
        static async Task Main(string[] args)
        {
            IHttpServer server = new HttpServer();
            

            server.AddRoute("/", HomePage);
            server.AddRoute("/about", About);
            server.AddRoute("/users/login", Login);

            await server.StartAsync(8081);

            static HttpResponse HomePage( HttpRequest request)
            {
                var html = "<h1>Welcome to SUS</h1>";
                var response = new HttpResponse("text/html",html);
                return response;
            }
            static HttpResponse About(HttpRequest request)
            {
                var html = "<h1>About SUS</h1>";
                var response = new HttpResponse("text/html", html);
                return response;
            }
            static HttpResponse Login(HttpRequest request)
            {
                var html = "<h1>Login</h1>";
                var response = new HttpResponse("text/html", html);
                return response;
            }
            
        }
    }
}
