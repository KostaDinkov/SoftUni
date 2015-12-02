//--------------------------------------------------------------------------------------------------------
// SoftUni
// Course:      OOP
// Lecture:     Inheritance And Abstraction
// Problem:     2. Animals
// Description: Create an abstract class Animal holding name, age and gender.
//              •	Create a hierarchy with classes Dog, Frog, Cat, Kitten and Tomcat.Dogs, 
//                      frogs and cats are animals.Kittens are female cats and Tomcats are 
//                      male cats.Define useful constructors and methods.
//              •	Define an interface ISoundProducible which holds the method ProduceSound(). 
//              All animals should implement this interface. The ProduceSound() method should 
//                  produce a specific sound depending on the animal invoking it(e.g.the dog should bark).
//              •	Create an array of different kinds of animals and calculate the 
//                  average age of each kind of animal using LINQ.
//
// Date:        Thursday 11.2015 19:22 
//--------------------------------------------------------------------------------------------------------

namespace _02.Animals
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            Kitten[] kittens = new[]
            {
                new Kitten("Hello Kitty", 4),
                new Kitten("Catwoman", 6),
                new Kitten("Thunder cat", 11)
            };

            Tomcat[] tomcats = new[]
            {
                new Tomcat("Mr. Bigglesworth", 2),
                new Tomcat("Felix", 5),
                new Tomcat("Tom", 2)
            };

            Dog[] dogs = new Dog[]
            {
                new Dog("Brian Griffin", 2, Genders.Male),
                new Dog("Too stupid dog", 5, Genders.Male),
                new Dog("Eddie from Frasier", 7, Genders.Male)
            };

            Frog[] frogs = new[]
            {
                new Frog("Hypnotoad from Futurama", 13, Genders.Male),
                new Frog("Kermit", 50, Genders.Male),
                new Frog("Prince Charming", 30, Genders.Male),
            };

            Console.WriteLine("Average kitten age: {0}", kittens.Average(n => n.Age));
            Console.WriteLine("Average tomcat age: {0}", tomcats.Average(n => n.Age));
            Console.WriteLine("Average dog age: {0}", dogs.Average(n => n.Age));
            Console.WriteLine("Average frog age: {0}", frogs.Average(n => n.Age));
        }
    }
}