namespace HandmadeHTTPServer.Server.HTTP.Response
{
    using System.Text;
    using Enums;
    using Contracts;
    using Util;
    
    public abstract class HttpResponse:IHttpResponse
    {
        public IView View { get; protected set; }

        protected HttpResponse()
        {
            this.HeaderCollection = new HttpHeaderCollection();
         
        }

        protected HttpResponse(HttpStatusCode responseCode, IView view)
        {
            this.StatusCode = responseCode;
            this.View = view;
        }
        
        
        private HttpHeaderCollection HeaderCollection { get; set; }
        public HttpStatusCode StatusCode { get; protected set; }
        private string StatusMessage => this.StatusCode.ToStatusMessage();

        public void AddHeader(string key, string value)
        {
            this.HeaderCollection.Add(new HttpHeader(key,value));
        }

        public string Response
        {
            get
            {
                StringBuilder response = new StringBuilder();
                response.AppendLine($"HTTP/1.1 {(int) this.StatusCode} {this.StatusMessage}");
                response.AppendLine(this.HeaderCollection.ToString());
                response.AppendLine();

                if ((int) this.StatusCode < 300 || (int) this.StatusCode > 400)
                {
                    response.AppendLine(this.View.View());
                }
                   
                return response.ToString();
            }
        }
    }
}