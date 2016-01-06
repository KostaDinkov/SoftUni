namespace Empires.Objects.Buildings
{
    using System;
    using Resources;
    using Units;

    public class Barracks : Building
    {
        public override Type UnitType { get; } = typeof (Swordsman);
        public override int DefaultUnitTimer { get; } = 4;
        public override double UnitYield { get; } = 1;
        public override ResourceType ResourceType { get; } = ResourceType.Steel;
        public override int DefaultResourceTimer { get; } = 3;
        public override int ResourceYield { get; } = 10;
    }
}