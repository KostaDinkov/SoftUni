namespace TheatreGuide.Commands
{
    using System;

    internal class AddPerformanceCommand : Command
    {
        public AddPerformanceCommand(string commandLine) : base(commandLine)
        {
            this.Theatre = this.GetTheatreName();
            this.Performance = this.GetPerformance();
            this.Date = this.GetDate();
            this.Duration = this.GetDuration();
            this.Price = this.GetPrice();
        }

        public string Theatre { get; set; }
        public string Performance { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Duration { get; set; }
        public decimal Price { get; set; }
    }
}