namespace Empires.Objects.Units
{
    public class Swordsman : Unit
    {
        private const double DefaultHealth = 40;
        private const double DefaultAttackDmg = 13;

        public Swordsman()
            : base(DefaultHealth, DefaultAttackDmg)
        {
        }
    }
}