namespace TheatreGuide.Commands
{
    using System;
    using System.Globalization;
    using System.Linq;

    internal class Command
    {
        public Command(string commandLine)
        {
            this.CommandLine = commandLine;
            this.CommandName = this.GetCommand();
        }

        public string CommandName { get; set; }

        public string CommandLine { get; set; }

        public string GetCommand()
        {
            var commandParts = this.CommandLine.Split('(');
            var command = commandParts[0];
            return command;
        }

        protected string GetTheatreName()
        {
            return this.GetParts()[0];
        }
        
        public string GetPerformance()
        {
            return this.GetParts()[1];
        }

        public DateTime GetDate()
        {
            return DateTime.ParseExact(this.GetParts()[2], "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
        }

        public TimeSpan GetDuration()
        {
            return TimeSpan.Parse(this.GetParts()[3]);
        }

        public decimal GetPrice()
        {
            return decimal.Parse(this.GetParts()[4], NumberStyles.Float);
        }

        protected string[] GetParts()
        {
            var chiHuyParts1 = this.CommandLine.Split(new[] { '(', ',', ')' },
                StringSplitOptions.RemoveEmptyEntries);

            var commandParams = chiHuyParts1.Skip(1).Select(p => p.Trim()).ToArray();
            return commandParams;
        }
    }
}