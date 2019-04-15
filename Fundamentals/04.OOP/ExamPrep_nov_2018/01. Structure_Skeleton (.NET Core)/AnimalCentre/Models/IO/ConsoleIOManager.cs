using System;


namespace AnimalCentre.Models.IO
{
    class ConsoleIOManager:IOManager
    {
        public override string ReadLine()
        {
            return Console.ReadLine();
        }

        public override void WriteLIne(string text)
        {
             Console.WriteLine(text);
        }
    }
}
