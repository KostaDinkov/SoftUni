namespace Logger.Layouts
{
    using Appenders;

    public interface ILayout
    {
        string Format(EntryLevel eventLevel, string msg);
    }
}