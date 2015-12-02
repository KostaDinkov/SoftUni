namespace _01.HumanStudentWorker
{
    internal class Student : Human
    {
        private static ulong facultyNoCounter = 10000;

        public Student(string firstName, string lastName)
            : base(firstName, lastName)
        {
            FacultyNo = facultyNoCounter;
            facultyNoCounter ++;
        }

        public ulong FacultyNo { get; set; }

        public override string ToString()
        {
            return $"{FacultyNo}, {FirstName} {LastName}";
        }
    }
}