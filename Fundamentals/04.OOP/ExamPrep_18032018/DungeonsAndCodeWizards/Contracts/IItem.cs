using DungeonsAndCodeWizards.Models.Characters;
using DungeonsAndCodeWizards.Models.Items;

namespace DungeonsAndCodeWizards.Contracts
{
    internal interface IItem
    {
        void AffectCharacter(Character character);
    }
}