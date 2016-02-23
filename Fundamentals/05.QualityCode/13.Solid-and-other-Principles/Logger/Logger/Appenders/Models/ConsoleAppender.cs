namespace Logger.Appenders.Models
{
    using System;
    using Layouts;

    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout) : base(layout)
        {
        }

        public override void Append(EntryLevel eventLevel, string msg)
        {
            var formattedMsg = this.Layout.Format(eventLevel, msg);
            Console.WriteLine(formattedMsg);
        }
    }
}