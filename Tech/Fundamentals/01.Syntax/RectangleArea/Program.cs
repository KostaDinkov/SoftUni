using System;

namespace RectangleArea
{
    class Program
    {
        static void Main()
        {
            var width = double.Parse(Console.ReadLine());
            var height = double.Parse(Console.ReadLine());

            var area = CalcRectArea(width, height);
            Console.WriteLine(String.Format("{0:0.00}", area));
        }

        static double CalcRectArea(double width, double height)
        {
            return width * height;
        }
    }
}