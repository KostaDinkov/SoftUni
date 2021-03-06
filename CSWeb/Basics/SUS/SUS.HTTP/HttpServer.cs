﻿using System;
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
                    await ProcessClientAsync(tcpClient);
                }
            }
        }

        private async Task ProcessClientAsync(TcpClient tcpClient)
        {

            try
            {
                using (NetworkStream stream = tcpClient.GetStream())
                {
                    List<byte> data = new List<byte>();
                    byte[] buffer = new byte[HTTPConstants.BufferSize];
                    int position = 0;

                    while (true)
                    {
                        int count = await stream.ReadAsync(buffer, position, HTTPConstants.BufferSize);

                        if (count < HTTPConstants.BufferSize)
                        {
                            byte[] finalData = new byte[count];
                            Array.Copy(buffer, finalData, count);
                            data.AddRange(finalData);
                            break;
                        }
                        data.AddRange(buffer);
                        position += count;
                    }
                    var requestString = Encoding.UTF8.GetString(data.ToArray());
                    Console.WriteLine(requestString);
                    HttpRequest request = new HttpRequest(requestString);

                    HttpResponse response;
                    if (routeTable.ContainsKey(request.Path))
                    {

                        response = routeTable[request.Path](request);
                        
                        //response.Cookies.Add(new ResponseCookie("sid", Guid.NewGuid().ToString()) { IsHttpOnly = true, MaxAge = 24 * 60 * 60 });
                    }
                    else
                    {
                        var html = "<h1>404 </h1><p>The resource you are looking for was not found!</p>";
                        response = new HttpResponse("text/html", html, HttpStatusCode.NotFound);
                        
                    }
                    await stream.WriteAsync(response.ToByteArray(), 0, response.ToByteArray().Length);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
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
