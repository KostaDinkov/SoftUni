namespace TheatreGuide.Commands
{
    internal class AddThratreCommand : Command
    {
        public AddThratreCommand(string commandLine) : base(commandLine)
        {
            this.TheatreName = this.GetTheatreName();
        }

        public string TheatreName { get; set; }
    }
}