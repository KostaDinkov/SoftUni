namespace TheSlum.Items
{
    public class Injection : Bonus, Interfaces.ITimeoutable
    {
        public Injection(string id) : base(id, 200, 0, 0)
        {
            this.Timeout = 3;
            this.Countdown = 3;
        }
    }
}