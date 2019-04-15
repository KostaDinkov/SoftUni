using DungeonsAndCodeWizards.Models.Characters;

namespace DungeonsAndCodeWizards.Models.Items
{
    class ArmorRepairKit:Item
    {
        private const int DefaultWeight=10;
        public ArmorRepairKit(int weight = DefaultWeight) : base(weight)
        {
            Name = "ArmorRepairKit";
        }

        public override void AffectCharacter(Character character)
        {
            if (character.IsAlive)
            {
                character.Armor = character.BaseArmor;
            }
        }
    }
}
