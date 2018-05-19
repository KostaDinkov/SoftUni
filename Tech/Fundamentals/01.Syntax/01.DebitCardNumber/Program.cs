using System;

class Program
{
    private const int INPUT_LEN = 4;

    static void Main(string[] args)
    {
        var cardNumber = ProcessInput();
        Console.WriteLine(String.Join(" ", cardNumber));
    }

    static string[] ProcessInput()
    {
        var numbers = new string[4];

        for (int i = 0; i < INPUT_LEN; i++)
        {
            var input = int.Parse(Console.ReadLine());
            numbers[i] = String.Format("{0:0000}", input);
        }

        return numbers;
    }
}