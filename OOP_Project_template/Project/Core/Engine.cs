namespace Project.Core
{
    using Contracts;

    internal class Engine
    {
        private readonly IUserInterface userInterface;
        private readonly DataBase dataBase;
        private readonly ICommandFactory commandFactory;

        public Engine(IUserInterface userInterface, DataBase dataBase, ICommandFactory commandFactory)
        {
            this.userInterface = userInterface;
            this.dataBase = new DataBase();
            this.commandFactory = commandFactory;
        }

        public void Run()
        {
            var userInput = this.userInterface.ReadLine();
            var command = this.commandFactory.GetCommand(userInput);
            var result = command.Execute(this.dataBase);

            if (!string.IsNullOrEmpty(result))
            {
                this.userInterface.WriteLine(result);
            }
        }
    }
}