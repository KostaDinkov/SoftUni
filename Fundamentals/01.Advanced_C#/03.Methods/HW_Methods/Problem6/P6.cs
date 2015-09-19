//  SoftUni
//  Course:     Advanced C#
//  Lecture:    Methods
//  Problem:    6.Number Calculations
//              Write methods to calculate the minimum, maximum, average, 
//              sum and product of a given set of numbers. Overload the 
//              methods to work with numbers of type double and decimal.
//              Note: Do not use LINQ.

using System;

namespace Problem6
{
    class P6
    {
        static void Main(string[] args)
        {
            int[] numbers = {1, 4, 5, 10, 15, -3, -54, -11};// change numbers to test for custom cases
            
            //Note that if the array of numbers is too long, or the numbers are too big, result might be inaccurate
            // due to the capacity of the return data types
            Console.WriteLine(GetMin(numbers));
            Console.WriteLine(GetMax(numbers));
            Console.WriteLine(GetAvg(numbers));
            Console.WriteLine(GetSum(numbers));
            Console.WriteLine(GetProduct(numbers)); 
            
        }

        static int GetMin(params int[] numbers)
        {
            int min = int.MaxValue;
            foreach (var number in numbers)
            {
                if (number < min)
                {
                    min = number;
                }
            }
            return min;
        }
        static double GetMin(params double[] numbers)
        {
            double min = double.MaxValue;
            foreach (var number in numbers)
            {
                if (number < min)
                {
                    min = number;
                }
            }
            return min;
        }
        static decimal GetMin(params decimal[] numbers)
        {
            decimal min = decimal.MaxValue;
            foreach (var number in numbers)
            {
                if (number < min)
                {
                    min = number;
                }
            }
            return min;
        }

        static int GetMax(params int[] numbers)
        {
            int max = int.MinValue;
            foreach (var number in numbers)
            {
                if (number > max)
                {
                    max = number;
                }
            }
            return max;
        }
        static double GetMax(params double[] numbers)
        {
            double max = double.MinValue;
            foreach (var number in numbers)
            {
                if (number > max)
                {
                    max = number;
                }
            }
            return max;
        }
        static decimal GetMax(params decimal[] numbers)
        {
            decimal max = decimal.MinValue;
            foreach (var number in numbers)
            {
                if (number > max)
                {
                    max = number;
                }
            }
            return max;
        }

        static double GetAvg(params int[] numbers)
        {
            int numbersCount = numbers.Length;
            int sum = 0;
            foreach (var number in numbers)
            {
                sum += number;
            }
            return sum/numbersCount;
        }
        static double GetAvg(params double[] numbers)
        {
            int numbersCount = numbers.Length;
            double sum = 0;
            foreach (var number in numbers)
            {
                sum += number;
            }
            return sum / numbersCount;
        }
        static decimal GetAvg(params decimal[] numbers)
        {
            int numbersCount = numbers.Length;
            decimal sum = 0;
            foreach (var number in numbers)
            {
                sum = decimal.Add(sum, number);
            }
            return decimal.Divide(sum, numbersCount);
        }

        static long GetSum(params int[] numbers)
        {
            long sum = 0;
            foreach (var number in numbers)
            {
                sum += number;
            }
            return sum;
        }
        static double GetSum(params double[] numbers)
        {
            double sum = 0;
            foreach (var number in numbers)
            {
                sum += number;
            }
            return sum;
        }
        static Decimal GetSum(params decimal[] numbers)
        {

            decimal sum = 0;
            foreach (var number in numbers)
            {
                sum = Decimal.Add(sum, number);
            }
            return sum;
        }

        static long GetProduct(params int[] numbers)
        {
            long product = 1;
            foreach (var number in numbers)
            {
                product *= number;
            }
            return product;

        }
        static double GetProduct(params double[] numbers)
        {
            double product = 1;
            foreach (var number in numbers)
            {
                product *= number;
            }
            return product;

        }
        static decimal GetProduct(params decimal[] numbers)
        {
            decimal product = 1;
            foreach (var number in numbers)
            {
                product = Decimal.Multiply(product,number);
            }
            return product;

        }

    }
}
