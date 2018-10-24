using System;

namespace Problem_1_RageExpenses
{
    class Program
    {
        static void Main()
        {
            var loses = int.Parse(Console.ReadLine());
            var headsetPrice = decimal.Parse(Console.ReadLine());
            var mousePrice = decimal.Parse(Console.ReadLine());
            var keyboardPrice = decimal.Parse(Console.ReadLine());
            var displayPrice = decimal.Parse(Console.ReadLine());

            var headsets = loses / 2;
            var mouses = loses / 3;
            var keyboards = loses / 6;
            var displays = keyboards / 2;

            var total = headsetPrice * headsets + mousePrice * mouses + keyboardPrice * keyboards +
                        displayPrice * displays;
            Console.WriteLine($"Rage expenses: {String.Format("{0:0.00}",total)} lv.");


        }
    }
}