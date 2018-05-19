using System;

namespace CharacterStats
{
    class Program
    {
        static void Main()
        {
            var name = Console.ReadLine();
            var curHealth = int.Parse(Console.ReadLine());
            var maxHealtth = int.Parse(Console.ReadLine());
            var curEnergy = int.Parse(Console.ReadLine());
            var maxEnergy = int.Parse(Console.ReadLine());

            Console.WriteLine(FormatStats(name, curHealth, maxHealtth, curEnergy, maxEnergy));
        }

        private static string FormatStats(string name, int curHealth, int maxHealtth, int curEnergy, int maxEnergy)
        {
            string health = $"Health: |{new string('|', curHealth)}{new string('.', maxHealtth - curHealth)}|";
            string energy = $"Energy: |{new string('|', curEnergy)}{new string('.', maxEnergy - curEnergy)}|";

            return $"Name: {name}\n{health}\n{energy}";
        }
    }
}