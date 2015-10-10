using System;
using System.Collections.Generic;
using System.Linq;


namespace _04.PopulationCounter
{
    class Program
    {
        static void Main()
        {
            //string filepath = "../../input.txt";
            var countryList = new Dictionary<string,Dictionary<string,long>>() ;

            //using (TextReader reader = new StreamReader(filepath))
            {
                //Console.SetIn(reader);
                //populate data
                
                string line;
                while ((line=Console.ReadLine())!="report")
                {
                    string[] lineArguments = line.Split('|').ToArray();
                    string country = lineArguments[1];
                    string city = lineArguments[0];
                    int population = int.Parse(lineArguments[2]);

                    if (countryList.ContainsKey(country))
                    {
                        countryList[country].Add(city,population);
                    }
                    else
                    {
                        countryList.Add(country, new Dictionary<string, long>());
                        countryList[country].Add(city, population);
                    }
                }
                var sortedList = countryList.OrderByDescending(country => country.Value.Sum(city=> city.Value));

                foreach (var keyValuePair in sortedList)
                {
                    Console.WriteLine($"{keyValuePair.Key} (total population: {keyValuePair.Value.Sum(city => city.Value)})");
                    var sortedCities = keyValuePair.Value.OrderByDescending(city => city.Value);
                    foreach (var city in sortedCities)
                    {
                        Console.WriteLine($"=>{city.Key}: {city.Value}");
                    }
                }
                
                
            }
        }
    }

}
