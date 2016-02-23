namespace TheatreGuide.Commands
{
    internal class PrintPerformancesCommand : Command
    {
        public PrintPerformancesCommand(string commandLine) : base(commandLine)
        {
            this.TheatreName = this.GetTheatreName();
        }

        public string TheatreName { get; set; }
    }
}