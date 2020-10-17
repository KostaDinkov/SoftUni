using System;

namespace SUS.HTTP
{
    public class Cookie
    {
        public Cookie(string Name, string Value)
        {
            this.Name = Name;
            this.Value = Value;
        }
        public Cookie(string cookie)
        {
            var parts = cookie.Split(new[] { "=" }, 2, StringSplitOptions.None);
            Name = parts[0];
            Value = parts[1];
            CookieString = cookie;
        }

        public string Name { get; set; }
        public string Value { get; set; }

        public string CookieString { get; set; }

        public override string ToString()
        {
            return CookieString;
        }
    }
}