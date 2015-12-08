namespace _4.StudentClass
{
    using System;

    internal class Student
    {
        private int age;
        private string name;

        public Student(string name, int age)
        {
            this.Age = age;
            this.Name = name;
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                var onPropertyChanged = this.PropertyChanged;
                if (onPropertyChanged != null)
                    onPropertyChanged(this, new StudentEventArgs("Name", this.name, value));
                this.name = value;
            }
        }

        public int Age
        {
            get { return this.age; }
            set
            {
                var onPropertyChanged = this.PropertyChanged;
                if (onPropertyChanged != null)
                    onPropertyChanged(this, new StudentEventArgs("Age", this.age.ToString(), value.ToString()));
                this.age = value;
            }
        }

        public event EventHandler<StudentEventArgs> PropertyChanged;
    }

    internal class StudentEventArgs : EventArgs
    {
        public StudentEventArgs(string propName, string oldVal, string newVal)
        {
            this.PropertyName = propName;
            this.OldValue = oldVal;
            this.NewValue = newVal;
        }

        public string PropertyName { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
    }
}