namespace Empires
{
    using System.IO;
    using Engine;

    internal class Program
    {
        private static void Main(string[] args)
        {
             //change the default console input to a file
            GameEngine.SetInput(new StreamReader("input.txt"));
            GameEngine.Run();
        }
    }
}