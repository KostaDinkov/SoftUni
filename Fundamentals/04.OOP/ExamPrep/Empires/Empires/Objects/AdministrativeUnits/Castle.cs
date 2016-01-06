namespace Empires.Objects.AdministrativeUnits
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Buildings;
    using Resources;
    using Units;

    internal static class Castle
    {
        private static readonly List<IBuilding> buildings = new List<IBuilding>();
        private static readonly Dictionary<string, int> garrison = new Dictionary<string, int>();
        private static readonly Dictionary<string, int> treasury = new Dictionary<string, int>();

        public static void InitTreasury()
        {
            //add all available resources in the game to the treasury and set them to 0
            var resourceTypes = Enum.GetValues(typeof (ResourceType));
            foreach (var resourceType in resourceTypes)
            {
                treasury.Add(resourceType.ToString(), 0);
            }
        }

        public static void AddUnit(Unit unit)
        {
            var unitType = unit.GetType().Name;
            if (garrison.ContainsKey(unitType))
            {
                garrison[unitType]++;
            }
            else
            {
                garrison.Add(unitType, 1);
            }
        }

        public static void AddResource(Resource resource)
        {
            var resourceName = resource.Type.ToString();
            if (treasury.ContainsKey(resourceName))
            {
                treasury[resourceName] += resource.Quantity;
            }
            else
            {
                treasury.Add(resourceName, resource.Quantity);
            }
        }

        public static void AddBuilding(Building building)
        {
            buildings.Add(building);
        }

        public static string UnitsToString()
        {
            var result = new StringBuilder("Units:\n");
            if (garrison.Count == 0)
            {
                return result + "N/A\n";
            }
            foreach (var pair in garrison)
            {
                result.Append($"--{pair.Key}: {pair.Value}\n");
            }
            return result.ToString();
        }

        public static string TreasutyToString()
        {
            var result = new StringBuilder("Treasury:\n");
            foreach (var pair in treasury)
            {
                result.Append($"--{pair.Key}: {pair.Value}\n");
            }
            return result.ToString();
        }

        public static string BuildingsToString()
        {
            var result = new StringBuilder("Buildings:\n");
            foreach (var building in buildings)
            {
                result.Append(
                    $"--{building.GetType().Name}: {building.TurnsPassed} turns ({building.UnitTimer} turns until {building.UnitType.Name}, {building.ResourceTimer} turns until {building.ResourceType})\n");
            }
            return result.ToString();
        }
    }
}