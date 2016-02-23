namespace TheatreGuide.Exceptions
{
    using System;

    internal class TheatreNotFoundException : Exception
    {
        public TheatreNotFoundException(string msg)
            : base(msg)
        {
        }
    }
}