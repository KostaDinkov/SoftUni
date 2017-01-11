namespace Project.Custom
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Contracts;

    internal class CustomCommandFactory : ICommandFactory
    {
        private readonly ICommandParser commandParser;

        public CustomCommandFactory(ICommandParser parser)
        {
            this.commandParser = parser;
        }

        public ICommand GetCommand(string userInput)
        {
            var parameters = this.commandParser.Parse(userInput);
            
            // TODO Implement command creation

            string commandName = parameters[0];
            string message = parameters[1];

            Type commandType = Assembly.GetExecutingAssembly().GetTypes().First(t => t.Name == commandName);
            ICommand result = (ICommand) Activator.CreateInstance(commandType,message);
            return result;
            throw new NotImplementedException();
        }
    }
}