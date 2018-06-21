using System;

namespace _1.ExtractEmails
{
    using System.Text.RegularExpressions;

    class ExtractEmails
    {
        static void Main()
        {
            var text = Console.ReadLine();
            var regex = new Regex(@"\s[a-zA-Z][a-zA-z\.\-_]+[a-zA-Z]@([a-zA-Z\-]+\.)+[a-zA-Z\-]+\b");

            var matches = regex.Matches(text);
            foreach (Match match in matches)
            {
                Console.WriteLine(match.Value);
            }
        }
    }
}