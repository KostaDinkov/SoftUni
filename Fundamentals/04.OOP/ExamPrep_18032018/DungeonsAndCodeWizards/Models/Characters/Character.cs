using System;
using DungeonsAndCodeWizards.Models.Bags;
using DungeonsAndCodeWizards.Models.Enums;
using DungeonsAndCodeWizards.Models.Items;

namespace DungeonsAndCodeWizards.Models.Characters
{
    public abstract class Character
    {
        private double armor;
        private double health;
        private string name;

        public Character(string name, double health, double armor, double abilityPoints, Bag bag,Faction faction)
        {
            IsAlive = true;
            Health = health;
            BaseHealth = health;

            Armor = armor;
            BaseArmor = armor;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be null or whitespace");
                }

                name = value;
            }
        }

        public double BaseArmor { get; private set; }
        public double BaseHealth { get; private set; }

        public double AbilityPoints { get; set; }
        public Bag Bag;
        public  Faction Faction { get; set; }

        public virtual double  RestHealMultiplier { get; set; }

        public double Armor
        {
            get => armor;
            set
            {
                armor += value;
                if (armor <= 0)
                {
                    armor = 0;
                }

                if (armor > BaseArmor)
                {
                    armor = BaseArmor;
                }
            }
        }


        public double Health
        {
            get => health;
            set
            {
                health += value;
                if (health <= 0)
                {
                    health = 0;
                    IsAlive = false;
                }

                if (health > BaseHealth)
                {
                    health = BaseHealth;
                }
            }
        }

        public bool IsAlive { get; set; }

        public void TakeDamage(double hitPoints)
        {
            if (IsAlive)
            {
                var overArmor = Armor - hitPoints;
                this.Armor -= hitPoints;
                if (overArmor > 0)
                {
                    Health -= hitPoints;
                }
            }
        }

        public void Rest()
        {
            if (IsAlive)
            {
                Health += BaseHealth * RestHealMultiplier;
            }
        }

        public void UseItem(Item item)
        {
            if (this.IsAlive)
            {
                item.AffectCharacter(this);
            }
        }

        public void UseItemOn(Item item, Character character)
        {
            if (character.IsAlive && IsAlive)
            {
                item.AffectCharacter(character);
            }
        }

        public void GiveCharacterItem(Item item, Character character)
        {
            if (character.IsAlive && IsAlive)
            {
                Bag.GetItem(item.GetType().Name);
                character.ReceiveItem(item);
            }
        }

        public void ReceiveItem(Item item)
        {
            Bag.AddItem(item);
        }


    }
}