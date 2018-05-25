using System;

namespace Problem7.CakeIngredients
{
    class CakeIngredients
    {
        static void Main()
        {
            int ingredientCount = 0;
            while (true)
            {
                var ingredient = Console.ReadLine();
                if (ingredient == "Bake!")
                {
                    break;
                }

                Console.WriteLine($"Adding ingredient {ingredient}.");
                ingredientCount++;

            }

            Console.WriteLine($"Preparing cake with {ingredientCount} ingredients.");
        }
    }
}