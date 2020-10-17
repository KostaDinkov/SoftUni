using System.Collections.Generic;
using System.Net;
using System.Text;

namespace SUS.HTTP
{
    public class HttpResponse
    {
        public HttpResponse(string contentType, string body, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            StatusCode = statusCode;
            Body = body;
            Headers = new List<Header>
            {
                new Header("Content-Type", contentType),
                new Header("Content-Length", Encoding.UTF8.GetBytes(body).Length.ToString()),
            };
            Cookies = new List<ResponseCookie>();
        }
        public ICollection<Header> Headers { get; set; }
        public HttpStatusCode StatusCode { get; set; }

        public string Body { get; set; }

        public override string ToString()
        {
            var responseBuilder = new StringBuilder();
            responseBuilder.Append($"HTTP/1.1 {StatusCode:d} {StatusCode}{HTTPConstants.NewLine}");

            foreach (var header in Headers)
            {
                responseBuilder.Append(header.ToString() + HTTPConstants.NewLine);
            }

            foreach (var responseCookie in Cookies)
            {
                responseBuilder.Append($"Set-Cookie: {responseCookie}{HTTPConstants.NewLine}");
            }

            responseBuilder.Append(HTTPConstants.NewLine);
            responseBuilder.Append(Body);

            return responseBuilder.ToString();
        }

        public byte[] ToByteArray()
        {
            return Encoding.UTF8.GetBytes(ToString());
        }

        public ICollection<ResponseCookie> Cookies { get; set; }
    }
}
