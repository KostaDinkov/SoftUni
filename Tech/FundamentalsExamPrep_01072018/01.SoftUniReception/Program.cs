using System;

namespace _01.SoftUniReception
{
    internal class Program
    {
        private static void Main()
        {
            //Console.SetIn(new StreamReader(@"..\..\..\test2.txt"));
            var kpd1 = int.Parse(Console.ReadLine());
            var kpd2 = int.Parse(Console.ReadLine());
            var kpd3 = int.Parse(Console.ReadLine());

            var count = int.Parse(Console.ReadLine());
            var hours = 1;

            if (count != 0)
            {
                while (count > 0)
                {
                    if (hours % 4 == 0 && hours != 0)
                    {
                        hours++;
                        continue;
                    }

                    count = count - (kpd1 + kpd2 + kpd3);
                    hours++;
                }
            }

            Console.WriteLine($"Time needed: {hours - 1}h.");
        }
    }
}