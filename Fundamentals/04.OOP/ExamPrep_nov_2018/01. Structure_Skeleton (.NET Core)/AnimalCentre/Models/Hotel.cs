using System;
using System.Collections.Generic;

using AnimalCentre.Models.Contracts;
using AnimalCentre.Models.Procedures;

namespace AnimalCentre.Models
{
    public class Hotel:IHotel
    {
        public Chip Chip { get; }

        public Vaccinate Vaccinate{get;}
        public Play Play { get; }
        public Fitness Fitness { get; }
        public NailTrim NailTrim { get; }
        public DentalCare DentalCare { get; }
        

        private const int Capacity = 10;
        private Dictionary<string, IAnimal> animals;
        public IReadOnlyDictionary<string,IAnimal> Animals => animals;

        public Hotel()
        {
            this.animals = new Dictionary<string, IAnimal>();
            Chip = new Chip();
            Vaccinate = new Vaccinate();
            Play = new Play();
            Fitness = new Fitness();
            NailTrim = new NailTrim();
            DentalCare = new DentalCare();
        }

        public void Accommodate(IAnimal animal)
        {
            CheckCapacity();
            CheckDuplicate(animal);
            animals.Add(animal.Name,animal);

        }

        public void Adopt(string animalName, string owner)
        {
            CheckAnimal(animalName);
            animals[animalName].Owner = owner;
            animals[animalName].IsAdopt = true;
            animals.Remove(animalName);
        }

        private void CheckAnimal(string animalName)
        {
            if (!animals.ContainsKey(animalName))
            {
                throw new ArgumentException($"Animal {animalName} does not exist");
            }
        }

        private void CheckDuplicate(IAnimal animal)
        {
            if (animals.ContainsKey(animal.Name))
            {
                throw new ArgumentException($"Animal {animal.Name} already exist");
            }
        }

        private void CheckCapacity()
        {
            if (animals.Count >= Capacity)
            {
                throw new InvalidOperationException("Not enough capacity");
            }
        }
    }
}
