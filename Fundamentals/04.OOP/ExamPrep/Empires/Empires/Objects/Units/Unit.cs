namespace Empires.Objects.Units
{
    public abstract class Unit : GameObject, IUnit
    {
        private double health;

        protected Unit(double health, double attackDmg)
        {
            this.Health = health;
            this.AttackDmg = attackDmg;
        }

        public double AttackDmg { get; set; }

        public double Health
        {
            get { return this.health; }
            set
            {
                this.health = value;
                if (this.Health <= 0) this.health = 0;
            }
        }
    }
}