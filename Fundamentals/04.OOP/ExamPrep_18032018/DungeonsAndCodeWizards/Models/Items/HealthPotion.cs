using System;
using DungeonsAndCodeWizards.Models.Characters;

namespace DungeonsAndCodeWizards.Models.Items
{
    class HealthPotion:Item
    {
        private const int DefaultWeight = 5;
        private const int HealthBoost = 20;
        public HealthPotion(int weight = DefaultWeight):base(weight)
        {
            Name = "HealthPotion";
        }

        public override void AffectCharacter(Character character)
        {
            if (character.IsAlive)
            {
                character.Health += HealthBoost;
            }
            else
            {
                throw new InvalidOperationException("Must be alive to perform this action");
            }
        }
    }
}
