using System;

namespace _3.CameraView
{
    using System.Linq;
    using System.Text.RegularExpressions;

    class CameraView
    {
        static void Main(string[] args)
        {
            var tokens = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            var skip = tokens[0];
            var take = tokens[1];

            var text = Console.ReadLine();
            var regexString = @"\|<(\w{"+skip+@"})(\w{0,"+take+"})";

            var regex = new Regex(regexString);

            var matches = regex.Matches(text);

            var results = matches.Select(m => m.Groups[2].Value);
            
            Console.WriteLine(String.Join(", ",results));

        }
    }
}