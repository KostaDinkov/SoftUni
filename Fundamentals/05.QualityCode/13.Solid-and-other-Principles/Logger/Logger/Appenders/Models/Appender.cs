namespace Logger.Appenders.Models
{
    using Contracts;
    using Layouts;

    public abstract class Appender : IAppender
    {
        public Appender(ILayout layout)
        {
            this.Layout = layout;
        }
        public EntryLevel ReportLevel { get; set; }
        public ILayout Layout { get; set; }
        public abstract void Append(EntryLevel eventLevel, string msg);
    }
}