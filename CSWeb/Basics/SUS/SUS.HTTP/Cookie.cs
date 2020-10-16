namespace SUS.HTTP
{
    public class Cookie
    {
        public string Name { get; set; }
        public string Value { get; set; }

        public string CookieString { get; set; }

        public override string ToString()
        {
            return CookieString;
        }
    }
}