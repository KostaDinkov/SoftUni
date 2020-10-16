using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace SUS.HTTP
{
    public class HttpRequest
    {
        public HttpRequest(string requestString)
        {
            RequestString = requestString;
            Headers = new List<Header>();
            Cookies = new List<Cookie>();

            //Parse Headers
            var lines = requestString.Split(new[]{HTTPConstants.NewLine}, StringSplitOptions.None);
            var firstLineParams = lines[0].Split(new []{" "},StringSplitOptions.None);
            Method = (HttpMethod)Enum.Parse(typeof(HttpMethod),firstLineParams[0],true);
            Path = firstLineParams[1];

            var lineIndex = 1;
            bool isInHeaders = true;
            while (lineIndex < lines.Length)
            {
                if (string.IsNullOrWhiteSpace(lines[lineIndex]))
                {
                    isInHeaders = false;
                    lineIndex++;
                    continue;
                }

                if (isInHeaders)
                {
                    Headers.Add(new Header(lines[lineIndex]));
                }
                else
                {
                    // Append Body
                    StringBuilder body = new StringBuilder();
                    for (int i = lineIndex; i < lines.Length; i++)
                    {
                        body.AppendLine(lines[i]);
                    }

                    this.Body = body.ToString();
                    break;
                }

                lineIndex++;
            }

            // Parse Cookies
            try
            {
                var cookieHeader = Headers.First(h => h.Name == "Cookie");
                var cookies = cookieHeader.Value.Split(new[] {"; "},StringSplitOptions.None);
                foreach (var cookie in cookies)
                {
                    var parts = cookie.Split(new[] {"="}, StringSplitOptions.None);

                    Cookies.Add(new Cookie{Name = parts[0],Value = parts[1], CookieString = cookie});
                }

                Cookies.ToList().ForEach(Console.WriteLine);
            }
            catch (InvalidOperationException e)
            {
                // Console.WriteLine("No cookies in request");
            }
            
        }

        public string Body { get; set; }

        public ICollection<Header> Headers { get; set; }
        public string Path { get; set; }
        public HttpMethod Method { get; set; }

        public ICollection<Cookie> Cookies { get; set; }
        public string RequestString { get; private set; }

        public override string ToString()
        {
            return RequestString;
        }
    }
}
