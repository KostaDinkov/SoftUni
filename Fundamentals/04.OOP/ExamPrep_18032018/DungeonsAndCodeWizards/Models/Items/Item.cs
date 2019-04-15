using DungeonsAndCodeWizards.Contracts;
using DungeonsAndCodeWizards.Models.Characters;

namespace DungeonsAndCodeWizards.Models.Items
{
    public abstract class Item : IItem
    {
        public string Name { get; internal set; }
        public int Weight;
        public Item(int weight)
        {
            this.Weight = weight;
        }
        public abstract void AffectCharacter(Character character);

        

    }
}
