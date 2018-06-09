using System;
using System.Text;

class NumbersInReversedOrder
    {
        static void Main()
        {
            var input = Console.ReadLine();
            Console.WriteLine(ReverseStr(input));
        }

        static string ReverseStr(string input)
        {
            StringBuilder result = new StringBuilder();

            for (int i = input.Length - 1; i >= 0; i--)
            {
                result.Append(input[i]);
            }

            return result.ToString();
        }
    }
