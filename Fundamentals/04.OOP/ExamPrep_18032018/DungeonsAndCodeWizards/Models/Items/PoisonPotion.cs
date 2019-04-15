using System;
using DungeonsAndCodeWizards.Models.Characters;

namespace DungeonsAndCodeWizards.Models.Items
{
    class PoisonPotion:Item
    {
        private const int DefaultWeight = 5;
        private const int HealthDamage = 20;
        public PoisonPotion(int weight = DefaultWeight) : base(weight)
        {
            Name = "PoisonPotion";
        }

        public override void AffectCharacter(Character character)
        {
            if (character.IsAlive)
            {
                character.Health -= HealthDamage;
            }
            else
            {
                throw new InvalidOperationException("Must be alive to perform this action");
            }
        }
    }
}
