
namespace _2.ExtractSentencesByKeyword
{
    using System.Text.RegularExpressions;
    using System;
    class ExtractSentencesByKeyword
    {
        static void Main(string[] args)
        {
            var term = Console.ReadLine();
            var text = Console.ReadLine();
            var regex = new Regex(@"([\.\!\?]|^)[^\.\!\?]*\b"+term+@"\b[^\.\?\!]*[\.\!\?]*?");

            var matches = regex.Matches(text);
            foreach (Match match in matches)
            {
                var result = match.Value.TrimStart(new[] {'!', '.', '?', ' '});
                result = result.TrimEnd(new[] {'!', '.', '?', ' '});
                Console.WriteLine(result);
            }
        }
    }
}