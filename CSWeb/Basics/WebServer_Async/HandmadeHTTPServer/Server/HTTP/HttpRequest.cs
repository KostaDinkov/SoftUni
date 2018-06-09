using System;
using System.Collections.Generic;
using System.Net;
using HandmadeHTTPServer.Server.Enums;
using HandmadeHTTPServer.Server.Exceptions;
using HandmadeHTTPServer.Server.HTTP.Contracts;

namespace HandmadeHTTPServer.Server.HTTP
{
    public class HttpRequest:IHttpRequest
    {
        public HttpRequest(string requestString)
        {
            this.FormData = new Dictionary<string, string>();
            this.HeaderCollection = new HttpHeaderCollection();
            this.QueryParameters = new Dictionary<string, string>();
            this.UrlParameters = new Dictionary<string, string>();

            this.ParseRequest(requestString);
        }

        private void ParseRequest(string requestString)
        {
            string[] requestLines = requestString.Split(new[] {Environment.NewLine}, StringSplitOptions.None);
            string[] requestLine = requestLines[0]
                .Trim()
                .Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);

            if (requestLine.Length != 3 || requestLine[2].ToLower() != "http/1.1")
            {
                throw new BadREquestException("Invalid request line");
            }

            this.RequestMethod = this.ParseRequestMethod(requestLine[0].ToUpper());
            this.Url = requestLine[1];
            this.Path = this.Url.Split(new[] {'?', '#'}, StringSplitOptions.RemoveEmptyEntries)[0];
            this.ParseHeaders(requestLines);
            this.ParseParameters();

            if (this.RequestMethod == HttpRequestMethod.POST)
            {
                this.ParseQuery(requestLines[requestLines.Length-1],this.FormData);
            }

        }

        private void ParseParameters()
        {
            if (!this.Url.Contains("?"))
            {
                return;
            }

            string query = this.Url.Split('?')[1];
            this.ParseQuery(query, this.QueryParameters);
        }

        private void ParseQuery(string query, Dictionary<string, string> queryParameters)
        {
            if (!query.Contains("="))
            {
                return;
            }

            string[] queryPairs = query.Split("&");
            foreach (var queryPair in queryPairs)
            {
                string[] pair = queryPair.Split("=");
                if (pair.Length != 2)
                {
                    continue;
                }
                queryParameters.Add(
                    WebUtility.UrlDecode(pair[0]),
                    WebUtility.UrlDecode(pair[1]));
            }

        }

        private void ParseHeaders(string[] requestLines)
        {
            int endIndex = Array.IndexOf(requestLines, string.Empty);
            for (int i = 1; i < endIndex; i++)
            {
                string[] headerArgs = requestLines[i].Split(new[] {": "}, StringSplitOptions.None);
                
                HttpHeader header = new HttpHeader(headerArgs[0],headerArgs[1]);
                this.HeaderCollection.Add(header);
            }

            if (!this.HeaderCollection.ContainsKey("Host"))
            {
                throw new BadREquestException("No Host header");
            }
        }

        private HttpRequestMethod ParseRequestMethod(string requestMethod)
        {
            try
            {
                return Enum.Parse<HttpRequestMethod>(requestMethod);
            }
            catch (ArgumentException e)
            {
                throw new BadREquestException("Invalid request method", e);
            }
        }

        public Dictionary<string, string> FormData { get; }
        public HttpHeaderCollection HeaderCollection { get; }
        public string Path { get; private set; }
        public Dictionary<string, string> QueryParameters { get; }
        public HttpRequestMethod RequestMethod { get; private set; }
        public string Url { get; private set; }
        public Dictionary<string, string> UrlParameters { get; }
        
        public void AddUrlParameter(string key, string value)
        {
            this.UrlParameters.Add(key,value);
        }
    }
}