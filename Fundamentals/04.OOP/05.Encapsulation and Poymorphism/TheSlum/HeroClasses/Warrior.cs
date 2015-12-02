namespace TheSlum.HeroClasses
{
    using System.Collections.Generic;
    using System.Linq;
    using GameEngine;
    using Items;

    public class Warrior : Character, Interfaces.IAttack
    {
        
        public Warrior(string id, int x, int y, Team team): base(id,x,y,200,100,team,2)
        {
            this.AttackPoints = 150;
        }

        public override Character GetTarget(IEnumerable<Character> targetsList)
        {
            return targetsList.FirstOrDefault(ch => (ch.Team != this.Team)&& ch.IsAlive && ch.Id != this.Id);
        }

        public override void AddToInventory(Item item)
        {
            this.Inventory.Add(item);
            this.AttackPoints  += item.AttackEffect;
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
            return base.ToString() + $" Attack: {this.AttackPoints}";
        }
        

        public int AttackPoints { get; set; }
    }
}