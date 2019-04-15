using System;
using System.Text;
using AnimalCentre.Models.Contracts;
using AnimalCentre.Models.IO;

namespace AnimalCentre.Models
{
    public class AnimalCentre
    {

        public Hotel Hotel { get; private set; }
        public IOManager IoManager { get; set; }

        public AnimalCentre()
        {
            Hotel = new Hotel();
            IoManager = new ConsoleIOManager(); //the default IO manager is set to the system console
        }

        public void Run()
        {
            string input = IoManager.ReadLine();

            while (input != "End")
            {
                ExecuteInput(input);

                input = IoManager.ReadLine();
            }
        }

        private void ExecuteInput(string input)
        {
            var strArgs = input.Split();
            var command = strArgs[0];
            switch (command)
            {
                case "RegisterAnimal":
                    IoManager.WriteLIne(this.RegisterAnimal(strArgs[1], strArgs[2], int.Parse(strArgs[3]), int.Parse(strArgs[4]),
                        int.Parse(strArgs[5])));
                    break;
                case "Chip":
                case "Vaccinate":
                case "Fitness":
                case "Play":
                case "DentalCare":
                case "NailTrim":
                    IoManager.WriteLIne((string)GetType().GetMethod(command).Invoke(this, new object[] { strArgs[1], int.Parse(strArgs[2]) }));
                    break;
                case "Adopt":
                    IoManager.WriteLIne(this.Adopt(strArgs[1], strArgs[2]));
                    break;
                case "History":
                    IoManager.WriteLIne(this.History(strArgs[1]));
                    break;
                default: break;
            }
        }


        public string RegisterAnimal(string type, string name, int energy, int happiness, int procedureTime)
        {
            Type animalType = Type.GetType($"AnimalCentre.Models.Animals.{type}");
            var animal = (IAnimal) Activator.CreateInstance(animalType, name, energy, happiness, procedureTime);
            Hotel.Accommodate(animal);

            return $"Animal {name} registered successfully";
        }

        public string Chip(string name, int procedureTime)
        {
            CheckName(name);
            var animal = Hotel.Animals[name];
            Hotel.Chip.DoService(animal,procedureTime);

            return $"{name} had chip procedure";

        }

        private void CheckName(string name)
        {
            if (!Hotel.Animals.ContainsKey(name))
            {
                throw new ArgumentException($"Animal {name} does not exist");
            }
        }

        public string Vaccinate(string name, int procedureTime)
        {
            CheckName(name);
            var animal = Hotel.Animals[name];
            Hotel.Vaccinate.DoService(animal, procedureTime);

            return $"{name} had vaccination procedure";
        }

        public string Fitness(string name, int procedureTime)
        {
            CheckName(name);
            var animal = Hotel.Animals[name];
            Hotel.Fitness.DoService(animal, procedureTime);

            return $"{name} had fitness procedure";
        }

        public string Play(string name, int procedureTime)
        {
            CheckName(name);
            var animal = Hotel.Animals[name];
            Hotel.Play.DoService(animal, procedureTime);
            
            return $"{name} was playing for {procedureTime} hours";
        }

        public string DentalCare(string name, int procedureTime)
        {
            CheckName(name);
            var animal = Hotel.Animals[name];
            Hotel.DentalCare.DoService(animal, procedureTime);

            return $"{name} had dental care procedure";
        }

        public string NailTrim(string name, int procedureTime)
        {
            CheckName(name);
            var animal = Hotel.Animals[name];
            Hotel.NailTrim.DoService(animal, procedureTime);

            return $"{name} had nail trim procedure";
        }

        public string Adopt(string animalName, string owner)
        {
            CheckName(animalName);
            var animal = Hotel.Animals[animalName];

            var isChipped = animal.IsChipped;
            Hotel.Adopt(animalName, owner);

            return $"{owner} adopted animal {(isChipped ? "with" : "without")} chip";
        }

        public string History(string type)
        {
            var procedure =  (IProcedure)Hotel.GetType().GetProperty(type).GetValue(Hotel);

            StringBuilder result = new StringBuilder();
            result.AppendLine(type);
            foreach (var animal in procedure.Animals)
            {
                result.AppendLine($"    Animal Type: {animal.GetType().Name} - {animal.Name} - Happiness: {animal.Happiness} - Energy: {animal.Energy}");
            }

            return result.ToString();
            

        }



    }
}
