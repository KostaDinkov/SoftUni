using System;

namespace _06.SumBigNumbers
{
    using System.Collections.Generic;
    

    class SumBigIntegers
    {
        static void Main()
        {
            var firstInput = Console.ReadLine().TrimStart('0');
            var secondInput = Console.ReadLine().TrimStart('0');
            var longestStrLen = Math.Max(firstInput.Length, secondInput.Length);

            var carry = 0;
            var result = new List<int>();
            for (int i = 0; i < longestStrLen; i++)
            {
                var first = 0;
                var second = 0;

                if (i < firstInput.Length)
                {
                    first = (int) char.GetNumericValue(firstInput[firstInput.Length - i-1]);
                }

                if (i < secondInput.Length)
                {
                    second = (int) char.GetNumericValue(secondInput[secondInput.Length - i-1]);
                }

                var sum = first + second + carry;
                carry = 0;
                if (sum >= 10)
                {
                    carry = 1;
                }

                sum = sum % 10;
                result.Add(sum);
            }

            if (carry == 1) result.Add(carry);
            result.Reverse();

            Console.WriteLine(string.Join("",result));
            
        }
    }
}