using System;

namespace _02.Animals
{
    internal class Dog : Animal, ISoundProducible
    {
        public Dog(string name, int age, Genders gender) : base(name, age, gender)
        {
        }

        public void ProduceSound()
        {
            Console.WriteLine("Woof, woof!");
        }
    }
}