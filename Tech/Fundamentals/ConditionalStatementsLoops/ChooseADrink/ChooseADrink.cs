using System;

namespace ChooseADrink
{
    class ChooseADrink
    {
        static void Main()
        {
            var proffession = Console.ReadLine();
            Console.WriteLine(GetDrink(proffession));
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
    }
}