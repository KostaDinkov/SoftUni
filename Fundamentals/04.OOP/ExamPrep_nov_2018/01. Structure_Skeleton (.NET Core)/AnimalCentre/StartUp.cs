using System;

namespace AnimalCentre
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var centre = new Models.AnimalCentre();
            centre.Run();
            
        }
    }
}
