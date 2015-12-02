namespace _02.Animals
{
    internal abstract class Animal
    {
        protected Animal(string name, int age, Genders gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public Genders Gender { get; set; }
    }
}