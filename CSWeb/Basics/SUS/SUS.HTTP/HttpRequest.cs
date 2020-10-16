using System;
using System.Collections.Generic;
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

            var lines = requestString.Split(new[]{HTTPConstants.NewLine}, StringSplitOptions.None);

            var firstLineParams = lines[0].Split(new []{" "},StringSplitOptions.None);
            Method = (HttpMethod)Enum.Parse(typeof(HttpMethod),firstLineParams[0].ToUpper());
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
        }

        public string Body { get; set; }

        public List<Header> Headers { get; set; }
        public string Path { get; set; }
        public HttpMethod Method { get; set; }

        public List<Cookie> Cookies { get; set; }
        public string RequestString { get; private set; }

        public override string ToString()
        {
            return RequestString;
        }
    }
}
