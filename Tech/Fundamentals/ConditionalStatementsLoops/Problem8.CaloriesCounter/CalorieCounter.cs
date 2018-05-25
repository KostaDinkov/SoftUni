using System;
using System.Collections.Generic;

namespace Problem8.CaloriesCounter
{
    
    class CalorieCounter
    {
        private static Dictionary<string,int> ingredientEnergy = new Dictionary<string, int>
        {
            {"cheese",500},
            {"tomato sauce",150},
            {"salami",600},
            {"pepper",50}
        };    
        static void Main()
        {
            var totalCalories = 0;
            var totalIngredients = int.Parse(Console.ReadLine());

            for (int i = 0; i < totalIngredients; i++)
            {
                var input = Console.ReadLine().ToLower();
                if (ingredientEnergy.ContainsKey(input))
                {
                    totalCalories += ingredientEnergy[input];
                }
            }

            Console.WriteLine($"Total calories: {totalCalories}");

        }
    }
}