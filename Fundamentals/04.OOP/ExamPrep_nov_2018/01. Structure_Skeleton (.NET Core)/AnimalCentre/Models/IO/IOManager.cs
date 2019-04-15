using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalCentre.Models.IO
{
    public abstract class IOManager
    {
        public abstract string ReadLine();
        public abstract void WriteLIne(string text);
    }
}
