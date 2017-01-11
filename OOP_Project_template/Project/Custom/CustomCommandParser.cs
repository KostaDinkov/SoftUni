namespace Project.Custom
{
    using System;
    using Contracts;

    internal class CustomCommandParser : ICommandParser
    {
        public string[] Parse(string input)
        {
            // TODO implement input parser

            // some test code here
            string[] parameters = input.Split(new[] {'(', ')'});
            return parameters;
            throw new NotImplementedException();
        }
    }
}