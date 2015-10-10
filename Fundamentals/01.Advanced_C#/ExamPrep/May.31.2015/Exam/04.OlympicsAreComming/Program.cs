using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _04.OlympicsAreComming
{
    class Program
    {
        static void Main()
        {
            string filePath = "../../input.txt";
            using (TextReader reader = new StreamReader(filePath))
            {
                Console.SetIn(reader);
                Dictionary<string, Dictionary<string,int>> data = new Dictionary<string, Dictionary<string, int>>();
                string entryLine = Console.ReadLine();
                while (entryLine != "report")
                {
                    string[] arguments = entryLine.Split('|').Select(e => e.Trim()).ToArray();
                    string country = Regex.Replace(arguments[1], @"\s+", " ");
                    string athlete = Regex.Replace(arguments[0], @"\s+", " ");
                    if (data.ContainsKey(country))
                    {
                        if (data[country].ContainsKey(athlete))
                        {
                            data[country][athlete] ++;
                        }
                        else
                        {
                            data[country].Add(athlete, 1);
                        }
                    }
                    else
                    {
                        data.Add(country, new Dictionary<string, int>());
                        data[country].Add(athlete,1);
                    }
                    entryLine = Console.ReadLine();
                }
                var dataByCountry = data.OrderByDescending(country => country.Value.Sum(ath => ath.Value));

                foreach (var country in dataByCountry)
                {
                    Console.WriteLine($"{country.Key} ({country.Value.Count} participants): {country.Value.Sum(ath => ath.Value)} wins");
                }
            }
            
        }
    }
}
