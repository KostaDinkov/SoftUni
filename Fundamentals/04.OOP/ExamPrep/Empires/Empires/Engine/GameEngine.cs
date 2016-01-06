namespace Empires.Engine
{
    using System;
    using System.IO;
    using Objects.AdministrativeUnits;
    using Utils;

    internal class GameEngine
    {
        public static void SetInput(TextReader reader)
        {
            Console.SetIn(reader);
        }

        public static event EventHandler TurnEnded;

        public static void Run()
        {
            Castle.InitTreasury();
            while (true)
            {
                var commandLine = Console.ReadLine();
                var commands = commandLine.Split();

                switch (commands[0])
                {
                    case "build":
                        Build(commands[1]);
                        break;
                    case "skip":
                        break;
                    case "empire-status":
                        Console.Write(Castle.TreasutyToString());
                        Console.Write(Castle.BuildingsToString());
                        Console.Write(Castle.UnitsToString());
                        break;
                    case "armistice":
                        return;
                    default:
                        break;
                }


                OnTurnEnded();
            }
        }

        private static void Build(string building)
        {
            building = char.ToUpper(building[0]) + building.Substring(1);
            var nameSpace = "Empires.Objects.Buildings.";
            var buildingType = Type.GetType(nameSpace + building);
            var obj = Activator.CreateInstance(buildingType);
            Castle.AddBuilding(Utils.CastTo(obj, buildingType));
        }

        public static void OnTurnEnded()
        {
            var handler = TurnEnded;
            if (TurnEnded != null)
            {
                TurnEnded(typeof (GameEngine), EventArgs.Empty);
            }
        }
    }
}