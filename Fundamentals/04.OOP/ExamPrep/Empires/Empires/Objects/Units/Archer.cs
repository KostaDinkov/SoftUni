namespace Empires.Objects.Units
{
    public class Archer : Unit
    {
        private const double DefaultHealth = 25;
        private const double DefaultAttackDmg = 7;

        public Archer()
            : base(DefaultHealth, DefaultAttackDmg)
        {
        }
    }
}