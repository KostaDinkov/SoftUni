namespace Project
{
    using Contracts;
    using Core;
    using Core.IO;
    using Custom;

    internal class ProjectMain
    {
        public static void Main()
        {
            ICommandParser parser = new CustomCommandParser();
            ICommandFactory commandFactory = new CustomCommandFactory(parser);
            var dataBase = new DataBase();

            var engine = new Engine(new ConsoleInterface(), dataBase, commandFactory);
            engine.Run();
        }
    }
}