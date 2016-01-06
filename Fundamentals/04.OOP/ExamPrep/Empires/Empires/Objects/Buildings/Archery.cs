namespace Empires.Objects.Buildings
{
    using System;
    using Resources;
    using Units;

    public class Archery : Building
    {
        public override Type UnitType { get; } = typeof (Archer);
        public override int DefaultUnitTimer { get; } = 3;
        public override double UnitYield { get; } = 1;
        public override ResourceType ResourceType { get; } = ResourceType.Gold;
        public override int DefaultResourceTimer { get; } = 2;
        public override int ResourceYield { get; } = 5;
    }
}