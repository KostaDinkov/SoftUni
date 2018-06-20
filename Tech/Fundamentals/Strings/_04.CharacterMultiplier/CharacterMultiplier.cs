using System;

namespace _04.CharacterMultiplier
{
    class CharacterMultiplier
    {
        static void Main()
        {
            var inputTokens = Console.ReadLine().Split(" ");
            var longer = Math.Max(inputTokens[0].Length, inputTokens[1].Length);
            var str1 = inputTokens[0];
            var str2 = inputTokens[1];
            

            var sum = 0;
            for (int i = 0; i < longer; i++)
            {
                var first= 1;
                var second = 1;
                if (i < str1.Length)
                {
                    first = str1[i];
                }

                if (i < str2.Length)
                {
                    second = str2[i];
                }

                sum += first * second;
            }

            Console.WriteLine(sum);
        }
        
        
    }
}