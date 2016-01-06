namespace Empires.Objects.Buildings
{
    using System;
    using AdministrativeUnits;
    using Engine;
    using Resources;
    using Units;
    using Utils;

    public abstract class Building : GameObject, IBuilding
    {
        protected Building()
        {
            // the turn that the building is created apparently doesn't count
            this.TurnsPassed = -1;
            this.EndTurnSubscribe();
            this.ResourceTimer = this.DefaultResourceTimer + 1;
            this.UnitTimer = this.DefaultUnitTimer + 1;
        }

        public abstract Type UnitType { get; }
        public abstract int DefaultUnitTimer { get; }
        public abstract double UnitYield { get; }
        public abstract ResourceType ResourceType { get; }
        public abstract int DefaultResourceTimer { get; }
        public abstract int ResourceYield { get; }
        public int UnitTimer { get; set; }
        public int ResourceTimer { get; set; }
        public int TurnsPassed { get; private set; }

        public virtual Resource ProduceResource()
        {
            return new Resource(this.ResourceType, this.ResourceYield);
        }

        public virtual Unit ProduceUnit()
        {
            var obj = Activator.CreateInstance(this.UnitType);
            return Utils.CastTo(obj, (this.UnitType));
        }

        private void EndTurnSubscribe()
        {
            GameEngine.TurnEnded += this.UpdateTimers;
        }

        private void UpdateTimers(object sender, EventArgs e)
        {
            this.TurnsPassed ++;
            this.ResourceTimer--;
            if (this.ResourceTimer == 0)
            {
                Castle.AddResource(this.ProduceResource());
                this.ResourceTimer = this.DefaultResourceTimer;
            }

            this.UnitTimer--;
            if (this.UnitTimer == 0)
            {
                Castle.AddUnit(this.ProduceUnit());
                this.UnitTimer = this.DefaultUnitTimer;
            }
        }
    }
}