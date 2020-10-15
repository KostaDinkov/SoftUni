using System;
using System.Net.Http.Headers;
using SUS.HTTP;

namespace FirstMvcApps
{
    class Program
    {
        static void Main(string[] args)
        {
            IHttpServer server = new HttpServer();
            

            server.AddRoute("/", HomePage);
            server.AddRoute("/about", About);
            server.AddRoute("/users/login", Login);


            static HttpResponse HomePage( HttpRequest request)
            {
                throw new NotImplementedException();
            }
            static HttpResponse About(HttpRequest request)
            {
                throw new NotImplementedException();
            }
            static HttpResponse Login(HttpRequest request)
            {
                throw new NotImplementedException();
            }
            server.StartAsync(80);
        }
    }
}
