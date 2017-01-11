namespace Project.Custom.Commands
{
    using System;
    using Contracts;

    internal class Print : ICommand
    {
        private string message;

        public Print(string message)
        {
            this.message = message;
        }
        public string Execute(object obj)
        {
            Console.WriteLine(this.message);
            

            return String.Empty;
        }
    }
}