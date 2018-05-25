using System;

namespace Problem12.TestNumbers
{
    class TestNumbers
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int maxSumThreshold = int.Parse(Console.ReadLine());
            
            int[] result = getTotalSum(n, m, maxSumThreshold);
            
            Console.WriteLine($"{result[1]} combinations");
            string extraString = result[0] >= maxSumThreshold?$" >= {maxSumThreshold}":String.Empty;
            
            Console.WriteLine($"Sum: {result[0]}{extraString}");
        }

        static int[] getTotalSum(int n, int m, int maxThreshold)
        {
            int totalSum = 0;
            int totalCombinations = 0;
            for (int i = n; i >= 1; i--)
            {
                for (int j = 1; j <= m; j++)
                {
                    totalSum += (i * j) * 3;
                    totalCombinations++;
                    if (totalSum >= maxThreshold)
                    {
                        return new  []{totalSum,totalCombinations};
                    }
                }
            }
            return new []{totalSum,totalCombinations};
        }
    }
}