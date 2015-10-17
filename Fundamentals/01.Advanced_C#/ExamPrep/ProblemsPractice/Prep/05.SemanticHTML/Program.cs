//This template is used for the SoftUni Exams
//It redirects from getting user input from the console to getting the input from a input.txt file
//NOTE: comment the 2 lines that have "//COMMNET THIS LINE" comments at the end, 
//to enable user input from the Console instead from the text file

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text.RegularExpressions;

namespace _05.SemanticHTML
{
    internal class Program
    {
        private static void Main()
        {
            string filePath = "../../input.txt";
            using (var reader = new StreamReader(filePath)) //COMMNET THIS LINE
            {
                Console.SetIn(reader); //COMMNET THIS LINE

                //New Code Starts Here
                string line = Console.ReadLine();
                while (line != "END")
                {
                    //check if line has opening div tag

                    if (Regex.IsMatch(line, @"<div[^>]*>"))
                    {
                        //search for id or class attributes
                        Match attribute = Regex.Match(line, @"(id|class)\s*=\s*""([^ ""]*)""");
                        if (attribute.Success)
                        {
                            string tag = "";
                            string tabs = Regex.Match(line, @"^\s*").Value;
                            tag = attribute.Groups[2].Value;
                            line = Regex.Replace(line, @"(id|class)\s*=\s*""([^ ""]*)""", "");
                            line = Regex.Replace(line, @"<div", "<" + tag);
                            line = Regex.Replace(line, @"\s+", " ");
                            line = Regex.Replace(line, @"\s+>", ">");
                            line = tabs + line;
                        }
                    }
                    //check if line has closing div tag
                    if (Regex.IsMatch(line, @"<\/div>\s*<!--\s*([^-\s*]*)\s*-->"))
                    {
                        line = Regex.Replace(line, @"<\/div>\s*<!--\s*([^-\s*]*)\s*-->", "</$1>");
                    }
                    Console.WriteLine(line);
                    line = Console.ReadLine();
                }
            }
        }
    }
}