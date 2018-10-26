using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Xml;

namespace _04.IronGirder
{
    class Program
    {
        static void Main(string[] args)
        {
            var cities = new Dictionary<string, Stats>();
            var input = Console.ReadLine();
            while (input != "Slide rule")
            {
                var(city,time,count) = ParseInput(input);

                AddEntry(city, time, count, cities);

                input = Console.ReadLine();
            }

            var sorted = cities.Where(p=>p.Value.BestTime>0 && p.Value.TotalPassengers>0).OrderBy(p => p.Value.BestTime).ThenBy(p => p.Key);
            foreach (var city in sorted)
            {
                Console.WriteLine($"{city.Key} -> Time: {city.Value.BestTime} -> Passengers: {city.Value.TotalPassengers}");
            }
        }

        private static void AddEntry(string city, int time, int count, Dictionary<string, Stats> cities)
        {
            if (cities.ContainsKey(city))
            {
                //ambush
                if (time == 0)
                {
                    cities[city].BestTime = 0;
                }
                else if (time < cities[city].BestTime || cities[city].BestTime ==0 ) 
                {
                    cities[city].BestTime = time;
                }

                cities[city].TotalPassengers += count;
                if (cities[city].TotalPassengers < 0)
                {
                    cities[city].TotalPassengers = 0;
                }
            }
            else
            {
                
                cities.Add(city, new Stats(){BestTime = time, TotalPassengers = count>0?count:0});
                
            }
        }

        private static (string , int, int ) ParseInput(string input)
        {
            var (city,stats ) = input.Split(":");
            var (timeStr, (countStr,rest)) = stats[0].Split("->");
            
            var isAmbushed = int.TryParse(timeStr, out var time);

            var count = isAmbushed ? int.Parse(countStr) : -int.Parse(countStr);

            return (city, time, count);
        }
    }

    class Stats
    {
        public int BestTime;
        public int TotalPassengers;
    }

    public static class ArrayExtensions
    {
        public static void Deconstruct<T>(this T[] array, out T first, out T[] rest )
        {
            first = array.Length > 0 ? array[0] : default(T);
            rest = array.Skip(1).ToArray();
        }
    }
}
