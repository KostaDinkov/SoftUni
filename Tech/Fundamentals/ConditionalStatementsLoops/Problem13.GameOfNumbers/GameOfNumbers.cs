using System;

namespace Problem13.GameOfNumbers
{
    class GameOfNumbers
    {
        static void Main()
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            int magic = int.Parse(Console.ReadLine());
            bool isMagicFound = false;
            int totalCombinations = 0;
            int[] lastMagicCombination = new int[2];
            
            for (int i = first; i <= second; i++)
            {
                for (int j = first; j <= second; j++)
                {
                    totalCombinations++;
                    if (i + j == magic)
                    {
                        lastMagicCombination = new[] {i, j};
                        isMagicFound = true;
                    }
                }
            }

            if (isMagicFound)
            {
                Console.WriteLine($"Number found! {lastMagicCombination[0]} + {lastMagicCombination[1]} = {magic}");
            }
            else
            {
                Console.WriteLine($"{totalCombinations} combinations - neither equals {magic}");
            }
        }
    }
}