namespace Logger.Appenders.Contracts
{
    public interface IFileAppender : IAppender
    {
        string File { get; set; }
    }
}