using HandmadeHTTPServer.Server.Enums;

namespace HandmadeHTTPServer.Server.Util
{
    public static class StatusCodeExtensions
    {
        public static string ToStatusMessage(this HttpStatusCode statusCode)
        {
            switch (statusCode)
            {
                case HttpStatusCode.Found: return "Found";
                case HttpStatusCode.InternalServerError: return "Internal Server Error";
                case HttpStatusCode.MovedPermanently: return "Moved Permanently";
                case HttpStatusCode.MovedTrmporarily: return "Moved Temprorarily";
                case HttpStatusCode.NotAuthorized: return "Not Authorized";
                case HttpStatusCode.NotFound: return "Not Found";
                case HttpStatusCode.OK: return "OK";
                default: return "";
            }
        }
    }
}