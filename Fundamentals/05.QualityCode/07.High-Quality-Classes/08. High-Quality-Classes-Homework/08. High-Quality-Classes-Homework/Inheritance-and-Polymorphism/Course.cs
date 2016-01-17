namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;

    public abstract class Course
    {
        private string name;
        private string teacherName;

        protected Course(string name)
        {
            this.Name = name;
        }

        protected Course(string courseName, string teacherName)
        {
            this.Name = courseName;
            this.TeacherName = teacherName;
        }

        protected Course(string courseName, string teacherName, IList<string> students)
        {
            this.Name = courseName;
            this.TeacherName = teacherName;
            this.Students = students;
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name cannot be null or empty.");
                }
                this.name = value;
            }
        }

        public string TeacherName
        {
            get { return this.teacherName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Teacher's name cannot be null or empty.");
                }
                this.teacherName = value;
            }
        }

        public IList<string> Students { get; set; } = new List<string>();

        internal string GetStudentsAsString()
        {
            if (this.Students == null || this.Students.Count == 0)
            {
                return "{ }";
            }
            return "{ " + string.Join(", ", this.Students) + " }";
        }
    }
}