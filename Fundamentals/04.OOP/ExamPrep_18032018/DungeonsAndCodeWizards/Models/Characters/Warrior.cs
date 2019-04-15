using System;
using DungeonsAndCodeWizards.Contracts;
using DungeonsAndCodeWizards.Models.Bags;
using DungeonsAndCodeWizards.Models.Enums;

namespace DungeonsAndCodeWizards.Models.Characters
{
    internal class Warrior : Character, IAttackable
    {
        private const double DefaultHealth = 100;
        private const double DefaultArmor = 50;
        private const int DefaultAbilityPoints = 40;

        public Warrior(string name, Faction faction)
            : base(name, DefaultHealth, DefaultArmor, DefaultAbilityPoints, new Satchel(), faction)
        {
        }


        public void Attack(Character character)
        {
            if (character == this)
            {
                throw new InvalidOperationException("Cannot attack self!");
            }

            if (character.Faction == Faction)
            {
                throw new ArgumentException($"Friendly fire! Both characters are from {Faction.ToString()} faction!" );
            }

            character.TakeDamage(AbilityPoints);
        }
    }
}