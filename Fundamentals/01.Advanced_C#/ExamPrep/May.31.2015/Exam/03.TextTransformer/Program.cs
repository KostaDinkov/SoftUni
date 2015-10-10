using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace _03.TextTransformer
{
    class Program
    {
        static void Main()
        {
            string inputFile = @"../../input.txt";
            using (TextReader reader = new StreamReader(inputFile))
            {
                Console.SetIn(reader);
                StringBuilder input = new StringBuilder();
                string inputLine = Console.ReadLine();

                while (inputLine != "burp")
                {
                    input.Append(inputLine);
                    inputLine = Console.ReadLine();
                }

                string processed = Regex.Replace(input.ToString(), @"\s+", " ");
                Regex regex = new Regex(@"(\$[^\$\%\&\']+\$)|(\%[^\$\%\&\']+\%)|(\&[^\$\%\&\']+\&)|(\'[^\$\%\&\']+\')");
                MatchCollection matches = regex.Matches(processed);
                List<string> results = new List<string>();

                foreach (Match match in matches)
                {
                    string encrypted = match.Value;
                    string decrypted = Decrypt(encrypted);
                    results.Add(decrypted);
                }
                Console.WriteLine(string.Join(" ", results));
            }
        }

        private static string Decrypt(string encrypted)
        {
            StringBuilder result = new StringBuilder();
            char specialSymbol = encrypted[0];
            int mod = 0;

            switch (specialSymbol)
            {
                case '$': mod = 1; break;
                case '%': mod = 2; break;
                case '&': mod = 3; break;
                case '\'': mod = 4; break;
            }
            string message = encrypted.Substring(1, encrypted.Length - 2);

            for (int index = 0; index < message.Length; index++)
            {
                if (index % 2 == 0)
                {
                    result.Append((char)(message[index] + mod));
                }
                else
                {
                    result.Append((char)(message[index] - mod));
                }
            }
            return result.ToString();
        }
    }
}
