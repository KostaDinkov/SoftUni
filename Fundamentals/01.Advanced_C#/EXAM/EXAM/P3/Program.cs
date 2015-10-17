//This template is used for the SoftUni Exams
//It redirects from getting user input from the console to getting the input from a input.txt file
//NOTE: comment the 2 lines that have "//COMMNET THIS LINE" comments at the end, 
//to enable user input from the Console instead from the text file
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace P3
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
                List<string> ints = new List<string>();
                List<string> doubles = new List<string>();
                string inputLine = Console.ReadLine();
                while (inputLine != "//END_OF_CODE")
                {
                    Match match = Regex.Match(inputLine, @"(int)\s([\w]+)|(double)\s([\w]+)");
                    if (match.Success)
                    {
                        if (match.Groups[1].Value == "int")
                        {
                            ints.Add(match.Groups[2].Value);
                        }
                        else
                        {
                            doubles.Add(match.Groups[4].Value);
                        } 
                    }
                    inputLine = Console.ReadLine();
                }
                if (doubles.Count!= 0)
                {
                    doubles.Sort();
                    Console.WriteLine($"Doubles: {String.Join(", ",doubles)} ");

                }
                else
                {
                    Console.WriteLine($"Doubles: None");
                }
                if (ints.Count != 0)
                {
                    ints.Sort();
                    Console.WriteLine($"Ints: {String.Join(", ", ints)} ");

                }
                else
                {
                    Console.WriteLine($"Ints: None");
                }

            }
        }
    }
}
