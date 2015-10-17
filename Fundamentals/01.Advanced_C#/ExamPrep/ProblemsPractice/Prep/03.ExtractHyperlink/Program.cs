//This template is used for the SoftUni Exams
//It redirects from getting user input from the console to getting the input from a input.txt file
//NOTE: comment the 2 lines that have "//COMMNET THIS LINE" comments at the end, 
//to enable user input from the Console instead from the text file
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _03.ExtractHyperlink
{
    class Program
    {
        static void Main()
        {
            string filePath = "../../input.txt";
            using (var reader = new StreamReader(filePath)) //COMMNET THIS LINE
            {
                Console.SetIn(reader);//COMMNET THIS LINE

                //New Code Starts Here
                string inputLine = Console.ReadLine();
                StringBuilder input = new StringBuilder();
                while (inputLine!="END")
                {
                    input.Append(inputLine);
                    inputLine = Console.ReadLine();
                }
                MatchCollection aTagMatches = Regex.Matches(input.ToString(), @"<a.[^>]*>");
                List<string>results = new List<string>();
                foreach (Match match in aTagMatches)
                {
                    string href =
                        Regex.Match(match.Value,
                            @"(href\s*=\s*"".[^""]*""[\s]*)|(href\s*=\s*'.[^']*'[\s]*)|(href\s*=\s*.[^""\s>]*[\s>])")
                                   .Value;
                    string result = href.Replace("href", "");
                    result = result.Trim();
                    result = result.Trim('=');
                    result = result.Trim();
                    result = result.Trim('\'', '\"','>');
                    if (result!="")
                    {
                        results.Add(result);
                    }
                }
                results.ForEach(r=> Console.WriteLine(r));
            }
        }
    }
}
