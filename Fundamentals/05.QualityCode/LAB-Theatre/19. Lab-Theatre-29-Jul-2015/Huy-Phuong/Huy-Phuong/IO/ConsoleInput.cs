namespace TheatreGuide
{
    using System;
    using Interfaces;

    internal class ConsoleInput:IInputMethod
    {
        public string GetInput()
        {
            return Console.ReadLine();
        }
    }
}