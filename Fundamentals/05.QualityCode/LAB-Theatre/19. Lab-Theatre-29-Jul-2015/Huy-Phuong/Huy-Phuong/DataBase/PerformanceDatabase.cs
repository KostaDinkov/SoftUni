namespace TheatreGuide
{
    using System;
    using System.Collections.Generic;
    using Exceptions;
    using Interfaces;

    internal class PerformanceDatabase : IPerformanceDatabase
    {
        private readonly Dictionary<string, HashSet<Performance>> db =
            new Dictionary<string, HashSet<Performance>>();

        public void AddTheatre(string theatreName)
        {
            //BUG: inversed true/false chek: FIXED
            if (this.db.ContainsKey(theatreName))
            {
                throw new DuplicateTheatreException("Duplicate theatre");
            }

            this.db[theatreName] = new HashSet<Performance>();
        }

        public IEnumerable<string> ListTheatres()
        {
            var theatres = this.db.Keys;
            return theatres;
        }

        void IPerformanceDatabase.AddPerformance(string theatre,
            string performanceName, DateTime date, TimeSpan duration, decimal ticketPrice)
        {
            if (!this.db.ContainsKey(theatre))
            {
                throw new TheatreNotFoundException("Theatre does not exist");
            }

            var performances = this.db[theatre];

            var endDate = date + duration;
            if (isOverlap(performances, date, endDate))
            {
                throw new TimeDurationOverlapException("Time/duration overlap");
            }

            var p = new Performance(theatre, performanceName, date, duration, ticketPrice);
            performances.Add(p);
        }

        public IEnumerable<Performance> ListAllPerformances()
        {
            var theatres = this.db.Keys;

            var result2 = new List<Performance>();
            foreach (var theatre in theatres)
            {
                var performances = this.db[theatre];
                result2.AddRange(performances);
            }

            return result2;
        }

        IEnumerable<Performance> IPerformanceDatabase.ListPerformances(string theatreName)
        {
            if (!this.db.ContainsKey(theatreName))
            {
                throw new TheatreNotFoundException("Theatre does not exist");
            }
            var asfd = this.db[theatreName];
            return asfd;
        }

        protected internal static bool isOverlap(IEnumerable<Performance> performances, DateTime startDate, DateTime endDate)
        {
            foreach (var performance in performances)
            {
                var performanceStart = performance.Date;
                var performanceEnd = performance.Date + performance.Duration;

                var isOverlap =
                    (performanceStart <= startDate && startDate <= performanceEnd) || 
                    (performanceStart <= endDate && endDate <= performanceEnd) || 
                    (startDate <= performanceStart && performanceStart <= endDate) || 
                    (startDate <= performanceEnd && performanceEnd <= endDate);

                if (isOverlap)
                {
                    return true;
                }
            }

            return false;
        }

        private class DuplicateTheatreException : Exception
        {
            public DuplicateTheatreException(string msg)
                : base(msg)
            {
            }
        }
    }
}