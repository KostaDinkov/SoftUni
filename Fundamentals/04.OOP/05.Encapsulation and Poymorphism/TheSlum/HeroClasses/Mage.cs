namespace TheSlum.HeroClasses
{
    using System.Collections.Generic;
    using System.Linq;
    using GameEngine;
    using Interfaces;
    using Items;

    public class Mage : Character, IAttack
    {
        public Mage(string id, int x, int y, Team team) : base(id, x, y, 150, 50, team, 5)
        {
            this.AttackPoints = 300;
        }

        public int AttackPoints { get; set; }

        public override Character GetTarget(IEnumerable<Character> targetsList)
        {
            return targetsList.LastOrDefault(ch => (ch.Team != this.Team) && ch.IsAlive && ch.Id != this.Id);
        }

        public override void AddToInventory(Item item)
        {
            this.Inventory.Add(item);
            this.AttackPoints += item.AttackEffect;
            this.ApplyItemEffects(item);
        }

        public override void RemoveFromInventory(Item item)
        {
            this.Inventory.Remove(item);
            this.AttackPoints -= item.AttackEffect;
            this.RemoveItemEffects(item);
        }

        public override string ToString()
        {
            return base.ToString() +$" Attack: {this.AttackPoints}";
        }
    }
}