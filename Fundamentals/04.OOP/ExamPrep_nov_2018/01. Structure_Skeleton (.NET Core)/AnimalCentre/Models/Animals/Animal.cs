using System;
using AnimalCentre.Models.Contracts;

namespace AnimalCentre.Models.Animals
{
    abstract class Animal : IAnimal
    {
        private int energy;
        private int happiness;
        private int procedureTime;
        private bool isChipped;
        public string Name { get; set; }

        public int Happiness
        {
            get => happiness;
            set => happiness = IntRangeValidator(value, 0, 100, "Invalid happiness");
        }

        public int Energy
        {
            get => energy;
            set => energy = this.IntRangeValidator(value, 0, 100, "Invalid energy");
        }

        public int ProcedureTime
        {
            get => procedureTime;
            set {
                if (value < 0)
                {
                    procedureTime = 0;
                }

                procedureTime = value;
            }
        }

        public string Owner { get; set; }
        public bool IsAdopt { get; set; }

        public bool IsChipped
        {
            get => isChipped;
            set {
                if (isChipped == true)
                {
                    throw new ArgumentException($"{this.Name} is already chipped");
                }

                this.isChipped = value;
            }
        }

        public bool IsVaccinated { get; set; }

        public int IntRangeValidator(int value, int start, int end, string msg)
        {
            if (value < start || value > end)
            {
                throw new ArgumentException(msg);
            }

            return value;
        }

        public Animal(string name, int energy, int happiness, int procedureTime)
        {
            Name = name;
            Energy = energy;
            Happiness = happiness;
            ProcedureTime = procedureTime;

            Owner = "Centre";
            IsAdopt = false;
            IsChipped = false;
            IsVaccinated = false;
        }
        public override string ToString()
        {
            return $"    Animal type: {GetType().Name} - {Name} - Happiness: {Happiness} - Energy: {Energy}";
        }
    }
}