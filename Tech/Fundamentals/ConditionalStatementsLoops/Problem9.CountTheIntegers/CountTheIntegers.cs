using System;

namespace Problem9.CountTheIntegers
{
    class CountTheIntegers
    {
        static void Main()
        {
            var totalNumbers = 0;
            while (true)
            {
                var input = Console.ReadLine();
                int result;
                if (!int.TryParse(input, out result))
                {
                    break;
                }

                totalNumbers++;
            }

            Console.WriteLine(totalNumbers);
        }
    }
}