using System;

class PrimeChecker
{
    static void Main()
    {
        var num = long.Parse(Console.ReadLine());
        Console.WriteLine(isPrime(num));
    }

    private static bool isPrime(long num)
    {
        if (num == 0 || num == 1)
        {
            return false;
        }

        for (int i = 2; i <= Math.Sqrt(num); i++)
        {
            if (num % i == 0)
            {
                return false;
            }
        }

        return true;
    }
}