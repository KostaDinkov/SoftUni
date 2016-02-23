namespace TheatreGuide
{
    using System;
    using Commands;
    using Interfaces;

    internal class Engine
    {
        internal Engine(IPerformanceDatabase db, IInputMethod inputMethod, IOutputMethod outputMethod)
        {
            this.InputMethod = inputMethod;
            this.OutputMethod = outputMethod;
            this.DataBase = db;
        }

        public IPerformanceDatabase DataBase { get; }

        public IInputMethod InputMethod { get; set; }

        public IOutputMethod OutputMethod { get; set; }

        public void Run()
        {
            while (true)
            {
                var commandLine = this.InputMethod.GetInput();

                this.ExecuteCommand(commandLine);
            }
        }

        private void ExecuteCommand(string commandLine)
        {
            if (!string.IsNullOrWhiteSpace(commandLine))
            {
                var command = new Command(commandLine);

                string commandResult;
                try
                {
                    switch (command.CommandName)
                    {
                        case "AddTheatre":

                            var addTheatreCmd =
                                new AddThratreCommand(commandLine);

                            commandResult =
                                CommandExecuter.ExecuteAddTheatreCommand(this.DataBase, addTheatreCmd);

                            break;

                        case "PrintAllTheatres":
                            commandResult =
                                CommandExecuter.ExecutePrintAllTheatresCommand(this.DataBase);

                            break;

                        case "AddPerformance":

                            var addPerformanceCmd =
                                new AddPerformanceCommand(commandLine);

                            commandResult =
                                CommandExecuter.ExecuteAddPerformanceCommand(this.DataBase, addPerformanceCmd);

                            break;

                        case "PrintAllPerformances":
                            commandResult = CommandExecuter.ExecutePrintAllPerformancesCommand(this.DataBase);

                            break;

                        case "PrintPerformances":

                            var printPerformances =
                                new PrintPerformancesCommand(commandLine);

                            commandResult =
                                CommandExecuter.ExecutePrintPerformancesCommand(this.DataBase, printPerformances);

                            break;

                        default:
                            commandResult = "Invalid command!";
                            break;
                    }

                    this.OutputMethod.Output(commandResult);
                }
                catch (Exception ex)
                {
                    OutputMethod.Output("Error: "+ ex.Message);
                    
                }
            }
        }
    }
}

