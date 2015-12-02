using System;

namespace _02.Animals
{
    internal class Frog : Animal, ISoundProducible
    {
        public Frog(string name, int age, Genders gender) : base(name, age, gender)
        {
        }

        public void ProduceSound()
        {
            Console.WriteLine("Ribbit");
        }
    }
}