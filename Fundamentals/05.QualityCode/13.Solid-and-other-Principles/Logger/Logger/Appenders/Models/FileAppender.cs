namespace Logger.Appenders.Models
{
    using System.IO;
    using Contracts;
    using Layouts;

    public class FileAppender : Appender, IFileAppender
    {
        public FileAppender(ILayout layout) : base(layout)
        {
        }
        
        public string File { get; set; }

        public override void Append(EntryLevel eventLevel, string msg)
        {
            var formattedMsg = this.Layout.Format(eventLevel, msg);
            using (var fileWriter = new StreamWriter(this.File, true))
            {
                fileWriter.WriteLine(formattedMsg);
            }
        }
    }
}