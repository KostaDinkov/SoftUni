namespace TheatreGuide.IO
{
    using System;
    using System.IO;
    using Interfaces;
    internal class FileInput:IInputMethod
    {
        private string filename;
        private StreamReader file;

        public FileInput(string filename)
        {
            this.filename = filename;
            this.file = new StreamReader(filename);
            
            
        }
        public string GetInput()
        {
            string line;
            
            
            if ((line = this.file.ReadLine()) == null)
            {
                this.file.Close();
                Environment.Exit(0);
            }
            
            return line;
        }
    }
}