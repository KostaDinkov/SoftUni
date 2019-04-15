using DungeonsAndCodeWizards.Models.Characters;
using DungeonsAndCodeWizards.Models.Items;

namespace DungeonsAndCodeWizards.Contracts
{
    public interface IHealable
    {
        void Heal(Character character);
    }
}