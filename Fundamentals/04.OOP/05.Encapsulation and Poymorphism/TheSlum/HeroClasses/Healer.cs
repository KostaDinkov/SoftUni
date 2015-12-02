namespace TheSlum.HeroClasses
{
    using System.Collections.Generic;
    using System.Linq;
    using GameEngine;
    using Interfaces;
    using Items;

    public class Healer : Character, IHeal
    {
        public Healer(string id, int x, int y, Team team)
            : base(id, x, y, 75, 50, team, 6)
        {
            this.HealingPoints = 60;
        }

        public int HealingPoints { get; set; }

        public override Character GetTarget(IEnumerable<Character> targetsList)
        {
            var allies = targetsList.Where(ch => ch.Team == this.Team && this.IsAlive && ch.Id!=this.Id).ToList();
            return allies.OrderBy(ch => ch.HealthPoints).First(); // TODO implement non sorting solution
        }

        public override void AddToInventory(Item item)
        {
            this.Inventory.Add(item);
            this.ApplyItemEffects(item);
            
        }

        public override void RemoveFromInventory(Item item)
        {
            this.Inventory.Remove(item);
            this.RemoveItemEffects(item);
        }

        public override string ToString()
        {
            return base.ToString() + $" Healing {this.HealingPoints}";
        }
    }
}