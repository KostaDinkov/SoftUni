using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03.PostOffice
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split('|');

            var capitalLetters = Regex.Match(input[0], @".*([#$%*&])([A-Z]+)(?:\1)").Groups[2];
           

            var uniqueCodes = new HashSet<string>();
            var matches = Regex.Matches(input[1], @"([6][5-9]|[7][0-9]|[8][0-9]|90):([0-1][1-9]|20)");
            foreach (Match match in matches)
            {
                uniqueCodes.Add(match.Value);
            }

            var results = new string[capitalLetters.Length];

            foreach (string uniqueCode in uniqueCodes)
            {
                var parameters = uniqueCode.Split(':').ToArray();
                var letter = (char) int.Parse(parameters[0]);
                var length = int.Parse(parameters[1]);
                var pattern = @"(?: |^)(" + letter + @"[^ ]{" + length + @"})(?: |$)";
                string match = Regex.Match(input[2],pattern).Groups[1].Value;
                results[capitalLetters.Value.IndexOf(letter)]=(match);
            }

            Console.WriteLine(string.Join('\n',results));



        }
    }
}
