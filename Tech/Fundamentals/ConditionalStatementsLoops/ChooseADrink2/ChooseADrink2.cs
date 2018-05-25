using System;
using System.Collections.Generic;

namespace ChooseADrink2
{
    class ChooseADrink2
    {
        private static readonly Dictionary<string, double> prices = new Dictionary<string, double>
        {
            {"Water", 0.7},
            {"Coffee", 1.0},
            {"Beer", 1.7},
            {"Tea", 1.2}
        };

        static void Main()
        {
            var proffession = Console.ReadLine();
            var quantity = int.Parse(Console.ReadLine());
            Console.WriteLine(
                $"The {proffession} has to pay {String.Format("{0:0.00}", CalculatePrice(GetDrink(proffession), quantity))}.");
        }

        static string GetDrink(string proffession)
        {
            switch (proffession)
            {
                case "Athlete":
                    return "Water";
                case "Businessman":
                case "Businesswoman":
                    return "Coffee";
                case "SoftUni Student":
                    return "Beer";
                default:
                    return "Tea";
            }
        }

        static double CalculatePrice(string drink, int quantity)
        {
            return quantity * prices[drink];
        }
    }
}