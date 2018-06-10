
using HandmadeHTTPServer.Application;
using HandmadeHTTPServer.Server;
using HandmadeHTTPServer.Server.Contracts;
using HandmadeHTTPServer.Server.Routing;
using HandmadeHTTPServer.Server.Routing.Contracts;

namespace HandmadeHTTPServer
{
    class Launcher:IRunnable
    {
        private WebServer webServer;
        static void Main()
        {
            new Launcher().Run();
        }


        public void Run()
        {
            IApplication app = new MainApplication();
            IAppRouteConfig routeConfig = new AppRouteConfig();
            app.Start(routeConfig);
            
            this.webServer = new WebServer(8230,routeConfig);
            this.webServer.Run();
            
        }
    }
}