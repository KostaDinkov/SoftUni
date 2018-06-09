using System.Collections.Generic;
using HandmadeHTTPServer.Server.HTTP.Contracts;

namespace HandmadeHTTPServer.Server.HTTP
{
    public class HttpHeaderCollection:IHttpHeaderCollection
    {
        private readonly Dictionary<string, HttpHeader> headers;

        public HttpHeaderCollection()
        {
            this.headers = new Dictionary<string, HttpHeader>();
        }

        public void Add(HttpHeader header)
        {
            this.headers.Add(header.Key,header);
        }

        public HttpHeader GetHeader(string key)
        {
            return this.headers[key];
        }

        public bool ContainsKey(string key)
        {
            return this.headers.ContainsKey(key);
        }

        public override string ToString()
        {
            return string.Join("\n", this.headers);
            }
    }
}