using System;


class HelloName
{
    static void Main()
    {
        var name = Console.ReadLine();
        printHelloName(name);
    }

    static void printHelloName(string name)
    {
        Console.WriteLine($"Hello, {name}!");
    }
}