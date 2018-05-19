using System;

namespace BeverageLabels
{
    class Program
    {
        static void Main()
        {
            var name = Console.ReadLine();
            var volume = int.Parse(Console.ReadLine());
            var energy = int.Parse(Console.ReadLine());
            var sugar = int.Parse(Console.ReadLine());

            Console.WriteLine(FormatResult(name, volume, energy, sugar));
        }

        static double TotalUnits(int totalVolume, int unitPer100)
        {
            return totalVolume * unitPer100 / 100.0;
        }

        static string FormatResult(string name, int volume, int energy, int sugar)
        {
            return $"{volume}ml {name}:\n{TotalUnits(volume, energy)}kcal, {TotalUnits(volume, sugar)}g sugars";
        }
    }
}