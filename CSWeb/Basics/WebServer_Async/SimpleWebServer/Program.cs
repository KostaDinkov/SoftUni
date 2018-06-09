using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SimpleWebServer
{
    class Program
    {
        static void Main()
        {
            var address = IPAddress.Parse("127.0.0.1");
            const int port = 3456;

            var server = new TcpListener(address, port);
            server.Start();

            Task.Run(async () => await Connect(server)).Wait();


        }

        static async Task Connect(TcpListener listener)
        {
            while (true)
            {
                var client = await listener.AcceptTcpClientAsync();

                var request = new byte[1024];
                await client.GetStream().ReadAsync(request, 0, request.Length);
               
                Console.WriteLine(Encoding.UTF8.GetString(request));
                var data = Encoding.UTF8.GetBytes("HTTP/1.1 200 OK\nContent-Type: text/html\n\nHello From Server");
                await client.GetStream().WriteAsync(data, 0, data.Length);
                client.Dispose();
            }
        }
    }
}