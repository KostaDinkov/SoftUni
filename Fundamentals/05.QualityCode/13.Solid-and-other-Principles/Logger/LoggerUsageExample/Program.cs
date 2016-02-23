namespace LoggerUsageExample
{
    using Logger.Appenders;
    using Logger.Appenders.Contracts;
    using Logger.Appenders.Models;
    using Logger.Layouts;
    using Logger.Loggers;

    internal class Program
    {
        private static void Main(string[] args)
        {
            ILayout simpleLayout = new SimpleLayout();
            
            //this is a client created layout implemented in the current project
            ILayout xmLayout = new XmLlayout();

            IAppender consoleAppender = new ConsoleAppender(simpleLayout);
            consoleAppender.ReportLevel = EntryLevel.Critical;

            IFileAppender fileAppender = new FileAppender(xmLayout);
            fileAppender.ReportLevel = EntryLevel.Info;
            fileAppender.File = "..\\..\\log.xml";

            ILogger logger = new Logger(consoleAppender, fileAppender);

            // NOTE: I have redesigned the logger class so that we can easily 
            // add additional levels of warnings (Debug for instance) without the need to edit the Logger class
            // Also I added a functionality to turn logging 'on' and 'off' without the need to comment or delete
            // existing logger.Log lines. Default value is 'on'.

            logger.IsLogging = false;

            logger.Log(EntryLevel.Info, "This is just an info message.");
            logger.Log(EntryLevel.Warning, "This is a warning.");
            logger.Log(EntryLevel.Error, "Error parsing JSON.");
            logger.Log(EntryLevel.Critical, "Situation is critical!");
            logger.Log(EntryLevel.Fatal, "Just Give Up");

            logger.IsLogging = true;

            logger.Log(EntryLevel.Info, "This is just an info message.");
            logger.Log(EntryLevel.Warning, "This is a warning.");
            logger.Log(EntryLevel.Error, "Error parsing JSON.");
            logger.Log(EntryLevel.Critical, "Situation is critical!");
            logger.Log(EntryLevel.Fatal, "Just Give Up");
        }
    }
}