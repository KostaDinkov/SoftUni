using System;

class MaxMethod
{
    static void Main()
    {
        int a = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());
        int c = int.Parse(Console.ReadLine());

        Console.WriteLine(GetMax(a, GetMax(b, c)));
    }

    static int GetMax(int a, int b)
    {
        return (a - b) > 0 ? a : b;
    }
}