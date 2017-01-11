namespace Project.Core.IO
{
    using System;
    using Contracts;

    internal class ConsoleInterface : IUserInterface
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public void WriteLine(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}