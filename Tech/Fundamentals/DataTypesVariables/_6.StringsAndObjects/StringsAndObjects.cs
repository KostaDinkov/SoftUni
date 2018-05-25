using System;

namespace _6.StringsAndObjects
{
    class StringsAndObjects
    {
        static void Main(string[] args)
        {
            string hello = "Hello";
            string world = "World";
            object helloWorldObj = hello + " " + world;
            string result = (string) helloWorldObj;
            Console.WriteLine(result);
        }
    }
}