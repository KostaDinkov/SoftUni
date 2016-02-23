namespace Logger.Loggers
{
    using System.Collections.Generic;
    using Appenders;
    using Appenders.Contracts;

    // NOTE: I have redesigned the logger class so that we can easily 
    // add additional levels of warnings (Debug for instance) without the need to edit the Logger class
    // I have left the old lines commented in the class
    // Also I added a functionality to turn logging 'on' and 'off' without the need to comment or delete
    // existing logger.Log lines. Default value is 'on'.

    public class Logger : ILogger
    {
        private readonly IList<IAppender> appenders = new List<IAppender>();

        public Logger(params IAppender[] appenders)
        {
            foreach (var appender in appenders)
            {
                this.appenders.Add(appender);
            }
        }

        public void Log(EntryLevel eventLevel, string msg)
        {
            if (this.IsLogging)
            {
                foreach (var appender in this.appenders)
                {
                    if (eventLevel >= appender.ReportLevel)
                    {
                        appender.Append(eventLevel, msg);
                    }
                }
            }
        }

        public bool IsLogging { get; set; } = true;

        //}
        //    this.CallAppenders(EntryLevel.Info, msg);
        //{

        //public void Info(string msg)

        //public void Warn(string msg)
        //{
        //    this.CallAppenders(EntryLevel.Warning, msg);
        //}

        //public void Error(string msg)
        //{
        //    this.CallAppenders(EntryLevel.Error, msg);
        //}

        //public void Critical(string msg)
        //{
        //    this.CallAppenders(EntryLevel.Critical, msg);
        //}

        //public void Fatal(string msg)
        //{
        //    this.CallAppenders(EntryLevel.Fatal, msg);
        //}

        //private void CallAppenders(EntryLevel level, string msg)
        //{
        //    foreach (var appender in this.appenders)
        //    {
        //        if (level >= appender.ReportLevel)
        //        {
        //            appender.Append(level, msg);
        //        }
        //    }
        //}
    }
}