namespace _01.HumanStudentWorker
{
    internal class Worker : Human
    {
        public Worker(string firstName, string lastName, double weekSalary, double workHoursPerDay)
            : base(firstName, lastName)
        {
            WeekSalary = weekSalary;
            WorkHoursPerDay = workHoursPerDay;
        }

        public Worker(string firstName, string lastName) : base(firstName, lastName)
        {
        }

        public double WeekSalary { get; set; }

        public double WorkHoursPerDay { get; set; }

        public override string ToString()
        {
            return
                $"{FirstName} {LastName}, week salary:{WeekSalary}, hours/day:{WorkHoursPerDay}, money/hour:{MoneyPerHour()}";
        }

        public double MoneyPerHour()
        {
            return WeekSalary/(WorkHoursPerDay*5); // assuming there are 5 working days per week;
        }
    }
}