namespace TheatreGuide
{
    using System;

    public class Performance : IComparable<Performance>
    {
        public Performance(string theatre, string pefrofmanceName, DateTime date, TimeSpan duration, decimal price)
        {
            this.Theatre = theatre;
            this.PefrofmanceName = pefrofmanceName;
            this.Date = date;
            this.Duration = duration;
            this.Price = price;
        }

        public string Theatre { get; protected internal set; }
        public string PefrofmanceName { get; }
        public DateTime Date { get; set; }

        public TimeSpan Duration { get; }

        protected internal decimal Price { get; protected set; }

        int IComparable<Performance>.CompareTo(Performance otherPerformance)
        {
            var tmp = this.Date.CompareTo(otherPerformance.Date);
            return tmp;
        }

        public override string ToString()
        {
            var result = string.Format(
                "Performance(Tr32: {0}; Tr23: {1}; date: {2}, duration: {3}, Gia: {4})",
                this.Theatre,
                this.PefrofmanceName,
                this.Date.ToString("dd.MM.yyyy HH:mm"), this.Duration.ToString("hh':'mm"), this.Price.ToString("f2"));
            return result;
        }
    }
}