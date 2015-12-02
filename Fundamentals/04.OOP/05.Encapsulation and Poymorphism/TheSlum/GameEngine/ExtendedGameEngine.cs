namespace TheSlum.GameEngine
{
    using System;
    using HeroClasses;
    using Items;

    public class ExtendedGameEngine : Engine
    {
        protected override void ExecuteCommand(string[] inputParams)
        {
            switch (inputParams[0])
            {
                case "status":
                    this.PrintCharactersStatus(this.characterList);
                    break;
                case "create":
                    this.CreateCharacter(inputParams);
                    break;
                case "add":
                    this.AddItem(inputParams);
                    break;
                default:
                    base.ExecuteCommand(inputParams);
                    break;
            }
        }

        protected override void CreateCharacter(string[] inputParams)
        {
            var id = inputParams[2];
            var x = int.Parse(inputParams[3]);
            var y = int.Parse(inputParams[4]);
            var team = (Team) Enum.Parse(typeof (Team), inputParams[5], true);
            switch (inputParams[1].ToLower())
            {
                case "warrior":
                    this.characterList.Add(new Warrior(id, x, y, team));
                    break;

                case "mage":

                    this.characterList.Add(new Mage(id, x, y, team));
                    break;

                case "healer":

                    this.characterList.Add(new Healer(id, x, y, team));
                    break;
            }
        }

        protected new void AddItem(string[] inputParams)
        {
            var newOwner = this.GetCharacterById(inputParams[1]);
            var itemId = inputParams[3];
            switch (inputParams[2])
            {
                case "axe":
                    newOwner.AddToInventory(new Axe(itemId));
                    break;
                case "injection":
                    newOwner.AddToInventory(new Injection(itemId));
                    break;
                case "pill":
                    newOwner.AddToInventory(new Pill(itemId));
                    break;
                case "shield":
                    newOwner.AddToInventory(new Shield(itemId));
                    break;

            }
        }
    }
}