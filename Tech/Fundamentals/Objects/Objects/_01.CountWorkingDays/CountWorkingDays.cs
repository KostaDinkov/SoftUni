namespace _01.CountWorkingDays
{
    using System;
    using System.Collections.Generic;

    internal class CountWorkingDays
    {
        private static readonly List<DateTime> holidays = new List<DateTime>
        {
            new DateTime(DateTime.Now.Year, 1, 1),
            new DateTime(DateTime.Now.Year, 3, 3),
            new DateTime(DateTime.Now.Year, 5, 1),
            new DateTime(DateTime.Now.Year, 5, 6),
            new DateTime(DateTime.Now.Year, 5, 24),
            new DateTime(DateTime.Now.Year, 9, 6),
            new DateTime(DateTime.Now.Year, 9, 22),
            new DateTime(DateTime.Now.Year, 11, 1),
            new DateTime(DateTime.Now.Year, 1, 1),
            new DateTime(DateTime.Now.Year, 12, 24),
            new DateTime(DateTime.Now.Year, 12, 25),
            new DateTime(DateTime.Now.Year, 12, 26)
        };

        private static void Main()
        {
            var startDate = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy", null);
            var endDate = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy", null);

            var workingDays = 0;

            foreach (var dateTime in DateRange(startDate, endDate))
                if (
                    dateTime.DayOfWeek != DayOfWeek.Sunday
                    && dateTime.DayOfWeek != DayOfWeek.Saturday
                    && !isHoliday(dateTime)
                )
                    workingDays++;

            Console.WriteLine(workingDays);
        }

        private static IEnumerable<DateTime> DateRange(DateTime from, DateTime thru)
        {
            for (var day = from.Date; day.Date <= thru.Date; day = day.AddDays(1))
                yield return day;
        }

        private static bool isHoliday(DateTime date)
        {
            foreach (var holiday in holidays)
                if (date.Day == holiday.Day && date.Month == holiday.Month)
                    return true;

            return false;
        }
    }
}