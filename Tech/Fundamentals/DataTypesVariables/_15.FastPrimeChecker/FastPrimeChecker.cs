using System;

class FastPrimeChecker
{
    static void Main()
    {
        int range = int.Parse(Console.ReadLine());
        for (int number = 2; number <= range; number++)
        {
            bool isPrime = true;
            for (int divisor = 2; divisor <= Math.Sqrt(number); divisor++)
            {
                if (number % divisor == 0)
                {
                    isPrime = false;
                    break;
                }
            }

            Console.WriteLine($"{number} -> {isPrime}");
        }
    }
}