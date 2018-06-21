using System;

namespace _4.Weather
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    class Weather
    {
        static void Main()
        {
            var cities = new Dictionary<string, CityWeather>();
            var regex = new Regex(@"([A-Z]{2})([0-9]{1,2}\.[0-9]{1,2})([a-zA-Z]+)\|");
            while (true)
            {
                var input = Console.ReadLine();
                if (input == "end") break;
                var match = regex.Match(input);
                if (!match.Success) continue;

                var cityCode = match.Groups[1].Value;
                var temp = double.Parse(match.Groups[2].Value);
                var condition = match.Groups[3].Value;

                if (cities.ContainsKey(cityCode))
                {
                    cities[cityCode].Condition = condition;
                    cities[cityCode].Temperature = temp;
                }
                else
                {
                    cities.Add(cityCode, new CityWeather(cityCode,temp,condition));
                }

                
            }

            var sorted = cities.OrderBy(c => c.Value.Temperature);
            foreach (var city in sorted)
            {
                Console.WriteLine($"{city.Key} => {String.Format("{0:0.00}",city.Value.Temperature)} => {city.Value.Condition}");
            }
        }
    }

    class CityWeather

    {
        public CityWeather(string cityCode, double temperature, string condition)
        {
            this.CityCode = cityCode;
            this.Temperature = temperature;
            this.Condition = condition;
        }
        public string CityCode { get; set; }
        public double Temperature { get; set; }
        public string Condition { get; set; }
    }
}