namespace Logger.Loggers
{
    using Appenders;

    public interface ILogger
    {
        void Log(EntryLevel eventLevel, string msg);

        bool IsLogging { get; set; }
        
        //void Info(string msg);
        //void Warn(string msg);
        //void Error(string msg);
        //void Critical(string msg);
        //void Fatal(string msg);
    }
}