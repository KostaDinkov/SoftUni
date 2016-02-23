namespace Logger.Layouts
{
    using System;
    using Appenders;

    public class SimpleLayout : ILayout
    {
        public string Format(EntryLevel eventLevel, string msg)
        {
            var timeStamp = DateTime.Now;
            string formattedMsg = $"{timeStamp} - {eventLevel} - {msg}";
            return formattedMsg;
        }
    }
}