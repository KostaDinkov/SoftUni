using System;
using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;


namespace SUS.HTTP
{
    public class HttpServer : IHttpServer
    {
        private const int BufferSize = 4096;
        IDictionary<string, Func<HttpRequest, HttpResponse>> routeTable = new Dictionary<string, Func<HttpRequest, HttpResponse>>();
        public void AddRoute(string path, Func<HttpRequest, HttpResponse> action)
        {
            if (routeTable.ContainsKey(path))
            {
                routeTable[path] = action;
            }
            else
            {
                routeTable.Add(path, action);
            }

        }

        public async Task StartAsync(int port)

        {
            if (PortInUse(port))
            {
                Console.WriteLine($"Port {port} is in use. Choose another.");
                return;
            }
            TcpListener tcpListener = new TcpListener(IPAddress.Loopback, port);
            tcpListener.Start();

            Console.WriteLine($"Server listening on port {port}");

            while (true)
            {
                using (TcpClient tcpClient = await tcpListener.AcceptTcpClientAsync())
                {
                    try
                    {
                        ProcessClientAsync(tcpClient);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
                }

            }
        }

        private async Task ProcessClientAsync(TcpClient tcpClient)
        {
            using (NetworkStream stream = tcpClient.GetStream())
            {
                List<byte> data = new List<byte>();
                byte[] buffer = new byte[BufferSize];
                int position = 0;

                while (true)
                {
                    int count = await stream.ReadAsync(buffer, position, BufferSize);

                    if (count < BufferSize)
                    {
                        byte[] finalData = new byte[count];
                        Array.Copy(buffer, finalData, count);
                        data.AddRange(finalData);
                        break;
                    }
                    else
                    {
                        data.AddRange(buffer);
                    }
                    position += count;
                }
                var request = Encoding.UTF8.GetString(data.ToArray());
                Console.WriteLine(request);


            }

        }

        public static bool PortInUse(int port)
        {
            bool inUse = false;

            IPGlobalProperties ipProperties = IPGlobalProperties.GetIPGlobalProperties();
            IPEndPoint[] ipEndPoints = ipProperties.GetActiveTcpListeners();


            foreach (IPEndPoint endPoint in ipEndPoints)
            {
                if (endPoint.Port == port)
                {
                    inUse = true;
                    break;
                }
            }


            return inUse;
        }
    }
}
