using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _03.RageQuit
{
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            input = input.ToUpper();

            
            
            MatchCollection matches = Regex.Matches(input, @"([^\d]+)(\d+)");
            StringBuilder result = new StringBuilder();
            foreach (Match part in matches)
            {
                string word = part.Groups[1].Value;
                int count = int.Parse(part.Groups[2].Value);
                for (int i = 0; i < count; i++)
                {
                    result.Append(word);
                }
            }
            int uniqueChars = result.ToString().Distinct().Count();
                Console.WriteLine("Unique symbols used: {0}", uniqueChars);
            Console.WriteLine(result);
        }
    }
}
