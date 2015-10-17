//This template is used for the SoftUni Exams
//It redirects from getting user input from the console to getting the input from a input.txt file
//NOTE: comment the 2 lines that have "//COMMNET THIS LINE" comments at the end, 
//to enable user input from the Console instead from the text file
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace P4
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
                var data = new Dictionary<string, Dictionary<string, int>>();
                while (inputLine != "End")
                {
                    try
                    {
                        if (!Regex.IsMatch(inputLine, @"(\w+\s){1,3}@(\w+\s){1,3}\d+\s\d+$"))
                        {
                            inputLine = Console.ReadLine();
                            continue;
                        }
                        string[] singerAndData = inputLine.Split('@');
                        if (singerAndData.Length != 2)
                        {
                            inputLine = Console.ReadLine();
                            continue;
                        }
                        string singer = singerAndData[0];
                        singer = singer.Trim();
                        string otherData = singerAndData[1];
                        if (singer == "" || otherData == "")
                        {
                            inputLine = Console.ReadLine();
                            continue;
                        }
                        string digitsData = Regex.Match(otherData, @"\s\d*\s\d*").Value;
                        digitsData = digitsData.Trim();
                        string[] priceCount = digitsData.Split(' ');
                        if (priceCount.Length>2)
                        {
                            inputLine = Console.ReadLine();
                            continue;
                        }
                        int price = int.Parse(priceCount[0]);
                        int ticketCount = int.Parse(priceCount[1]);
                        string venue = Regex.Match(inputLine, @"@[^\d]*").Value;
                        venue = venue.Trim();
                        venue = venue.Trim('@');

                        //add data
                        if (data.ContainsKey(venue))
                        {
                            if (data[venue].ContainsKey(singer))
                            {
                                data[venue][singer] += price * ticketCount;


                            }
                            else
                            {
                                data[venue].Add(singer, price * ticketCount);

                            }
                        }
                        else
                        {
                            data.Add(venue, new Dictionary<string, int>());
                            data[venue].Add(singer, price * ticketCount);

                        }
                    }
                    catch (FormatException)
                    {
                        inputLine = Console.ReadLine();
                        continue;
                    }
                    inputLine = Console.ReadLine();

                }
                //print data
                foreach (var venue in data)
                {
                    Console.WriteLine(venue.Key);
                    var sortedSingers = venue.Value.OrderByDescending(singer => singer.Value);
                    foreach (var sortedSinger in sortedSingers)
                    {
                        Console.WriteLine($"#  {sortedSinger.Key} -> {sortedSinger.Value}");
                    }
                }
            }
            
        }
    }
}
