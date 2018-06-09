using System;

    class FibonacciNumbers
    {
        static void Main()
        {
            int nthFibNum = int.Parse(Console.ReadLine());
            Console.WriteLine(Fib(nthFibNum+1));
        }

        static int Fib(int n)
        {
            double Phi = 1.61803398874989484820;
            double phi = 0.61803398874989484820;

            double sqrt5 = Math.Sqrt(5);
            return (int)((1 / sqrt5)*(Math.Pow((1 + sqrt5) / 2, n) - Math.Pow((1 - sqrt5) / 2, n)));
        }
    }
