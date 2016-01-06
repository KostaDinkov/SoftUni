namespace Empires.Objects.Buildings
{
    using System;
    using Resources;
    using Units;

    public interface IBuilding
    {
        Type UnitType { get; }
        int DefaultUnitTimer { get; }
        double UnitYield { get; }
        ResourceType ResourceType { get; }
        int DefaultResourceTimer { get; }
        int ResourceYield { get; }
        int ResourceTimer { get; }
        int UnitTimer { get; }
        int TurnsPassed { get; }
        Resource ProduceResource();
        Unit ProduceUnit();
    }
}