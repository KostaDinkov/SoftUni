namespace AnimalCentre.Models.Animals
{
    class Cat:Animal
    {
        public Cat(string name, int energy, int happiness, int procedureTime) : base(name, energy, happiness, procedureTime)
        {
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
