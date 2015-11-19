using System;

namespace _01.Persons
{
    internal class Person
    {
        private string name;
        private int age;
        private string email;

        public Person(string name, int age, string email)
        {
            Name = name;
            Age = age;
            Email = email;
        }

        public Person(string name, int age) : this(name, age, null)
        {
        }

        public override string ToString()
        {
            return ($"Name: {name}\nAge: {age}\nEmail: {email} ");
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    // the correct implementation would be to throw ArgumentNullException if the value is null
                    // and ArgumentException if the value is empty... but lets not be overly pedantic at this point
                    throw new ArgumentException("Invalid name");
                }
                name = value;
            }
        }

        public double Age
        {
            get { return age; }
            set
            {
                if (value < 1 || value > 100)
                {
                    throw new ArgumentOutOfRangeException();
                }
                age = (int) value;
            }
        }

        public string Email
        {
            get { return name; }
            set
            {
                if (value == null)
                {
                    email = null;
                }
                else if (value.Contains("@"))
                {
                    email = value;
                }

                else
                {
                    throw new ArgumentException();
                }
            }
        }
    }
}