namespace Logger.Appenders.Contracts
{
    using Layouts;
    public interface IAppender
    {
        EntryLevel ReportLevel { get; set; }
        ILayout Layout { get; set; }
        void Append(EntryLevel eventLevel, string msg);
    }
}