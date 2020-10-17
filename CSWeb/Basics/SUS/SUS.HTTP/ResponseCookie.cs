using System.Text;

namespace SUS.HTTP
{
    public class ResponseCookie : Cookie
    {
        public ResponseCookie(string name, string value) :
            base(name, value)
        {
            Path = "/";
        }

        public string Path { get; set; }
        public bool IsHttpOnly { get; set; }
        public int MaxAge { get; set; }

        public override string ToString()
        {
            var cookieBuilder = new StringBuilder();

            cookieBuilder.Append($"{Name}={Value}; Path={Path};");
            if (MaxAge != 0)
            {
                cookieBuilder.Append($" Max-Age={MaxAge};");
            }

            if (IsHttpOnly)
            {
                cookieBuilder.Append($" HttpOnly;");
            }

            return cookieBuilder.ToString();


        }
    }
}