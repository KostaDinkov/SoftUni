//This template is used for the SoftUni Exams
//It redirects from getting user input from the console to getting the input from a input.txt file
//NOTE: comment the 2 lines that have "//COMMNET THIS LINE" comments at the end, 
//to enable user input from the Console instead from the text file

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace _04.QueryMess
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

                List<string> partList = new List<string>();
                string inputLine = Console.ReadLine();
                while (inputLine != "END")
                {
                    string[] parts = inputLine.Split('?', '&');
                    Dictionary<string, List<string>> data = new Dictionary<string, List<string>>();
                    foreach (var part in parts)
                    {
                        string[] keyValue = part.Split('=');
                        if (keyValue.Length != 1)
                        {
                            string key = keyValue[0];
                            string value = keyValue[1];
                            key = RemoveWitespace(key);
                            value = RemoveWitespace(value);

                            if (data.ContainsKey(key))
                                data[key].Add(value);
                            else
                            {
                                data.Add(key, new List<string>());
                                data[key].Add(value);
                            }
                        }
                    }
                    foreach (var pair in data)
                    {
                        Console.Write($"{pair.Key}=[{string.Join(", ", pair.Value)}]");
                    }
                    Console.WriteLine();
                    inputLine = Console.ReadLine();
                }
            }
        }

        private static string RemoveWitespace(string key)
        {
            key = key.Replace("+", " ");
            key = key.Replace("%20", " ");
            key = Regex.Replace(key, @"\s+", " ");
            key = key.Trim();
            return key;
        }
    }
}