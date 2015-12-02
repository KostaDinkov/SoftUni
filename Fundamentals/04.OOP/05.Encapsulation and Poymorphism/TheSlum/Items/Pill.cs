namespace TheSlum.Items
{
    using Interfaces;

    public class Pill : Bonus, ITimeoutable
    {
        public Pill(string id) : base(id, 0, 0, 100)
        {
            this.Timeout = 1;
            this.Countdown = 1;
        }
    }
}