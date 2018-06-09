using System;

namespace HandmadeHTTPServer.Server.Exceptions
{
    public class BadREquestException : Exception
    {
        public BadREquestException()
        {
        }

        public BadREquestException(string message)
            : base(message)
        {
        }

        public BadREquestException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}