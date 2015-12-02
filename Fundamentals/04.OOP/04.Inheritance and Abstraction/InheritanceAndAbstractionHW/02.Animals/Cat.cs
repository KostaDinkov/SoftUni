using System;

namespace _02.Animals
{
    internal abstract class Cat : Animal, ISoundProducible
    {
        public Cat(string name, int age, Genders gender) : base(name, age, gender)
        {
        }

        public void ProduceSound()
        {
            Console.WriteLine("Miauuu");
        }
    }
}