using System;

namespace MilesToKilometers
{
    class Program
    {
        static void Main()
        {
            var input = double.Parse(Console.ReadLine());
            Console.WriteLine(String.Format("{0:0.00}", MilesToKilometers(input)));
        }

        static double MilesToKilometers(double miles)
        {
            return miles * 1.60934;
        }
    }
}