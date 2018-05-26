using System;


class IntegerToHexAndBinary
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        string numberInHex = Convert.ToString(number, 16).ToUpper();
        string numberInBinary = Convert.ToString(number, 2);

        Console.WriteLine(numberInHex);
        Console.WriteLine(numberInBinary);
    }
}