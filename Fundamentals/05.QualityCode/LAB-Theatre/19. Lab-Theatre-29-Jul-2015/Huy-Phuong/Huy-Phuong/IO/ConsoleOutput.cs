namespace TheatreGuide
{
    using System;
    using Interfaces;

    internal class ConsoleOutput : IOutputMethod
    {
        public void Output(string value)
        {
            Console.WriteLine(value);
        }
    }
}