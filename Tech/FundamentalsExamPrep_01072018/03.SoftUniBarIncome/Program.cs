//#define ReadFromFile

using System;
using System.Text.RegularExpressions;

namespace _03.SoftUniBarIncome
{
    internal class Program
    {
        private static void Main(string[] args)
        {
#if ReadFromFile
            Console.SetIn(new StreamReader("..\\..\\..\\test1.txt"));
#endif
            var totalIncome = 0d;
            var inputLine = Console.ReadLine();
            var pattern = new Regex(@"(?:%([A-Z]{1}[a-z]+)%).*?(?:<(\w+)>).*?(?:\|(\d+)\|).*?(?:(\d+(?:\.\d+)*)\$)");

            while (inputLine != "end of shift")
            {
                var parameters = pattern.Match(inputLine).Groups;
                if (parameters.Count == 5)
                {
                    var name = parameters[1].Value;
                    var product = parameters[2].Value;
                    var productCount = int.Parse(parameters[3].Value);
                    var price = double.Parse(parameters[4].Value);

                    totalIncome += productCount * price;

                    Console.WriteLine($"{name}: {product} - {Math.Round(productCount * price, 2):F2}");
                }

                inputLine = Console.ReadLine();
            }

            Console.WriteLine($"Total income: {Math.Round(totalIncome, 2):F2}");
        }
    }
}