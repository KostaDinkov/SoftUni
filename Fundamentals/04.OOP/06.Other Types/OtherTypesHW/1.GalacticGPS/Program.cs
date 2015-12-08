//---------------------------------------------------
// SoftUni
// Course:      OOP
// Lecture:     Other Types
// Problem:     1.Galactic GPS
// Description: Create a struct Location that holds fields of type double 
//              latitude and longitude of a given location. Create an enumeration Planet 
//                  that holds the following constants: Mercury, Venus, Earth, Mars, Jupiter, 
//                  Saturn, Uranus, Neptune.
//              •	Add an enum field of type Planet.Encapsulate all fields.Validate 
//                  data(search in Internet what are the valid ranges for latitude and longitude).
//              •	Add a constructor that holds 3 parameters: latitude, longitude and planet.
//              •	Override ToString() to print the current location in the 
//                  format<latitude>, <longitude> - <location>
//              
//
// Date:        Wednesday 12.2015 20:27 
// IDE:         Visual Studio 2015, C# v.6
//---------------------------------------------------

namespace _1.GalacticGPS
{
    using System;

    class Program
    {
        static void Main()
        {
            Location home = new Location(18.037986,28.870097,Planet.Earth);
            Console.WriteLine(home);
        }
    }
}
