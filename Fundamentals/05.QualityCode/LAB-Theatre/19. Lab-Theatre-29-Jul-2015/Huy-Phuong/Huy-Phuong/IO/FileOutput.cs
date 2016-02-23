namespace TheatreGuide.IO
{
    using System.IO;
    using Interfaces;

    internal class FileOutput : IOutputMethod
    {
        public FileOutput(string filename)
        {
            this.File = new StreamWriter(filename);
        }

        public StreamWriter File { get; set; }

        public void Output(string value)
        {
            this.File.WriteLine(value);
        }
    }
}