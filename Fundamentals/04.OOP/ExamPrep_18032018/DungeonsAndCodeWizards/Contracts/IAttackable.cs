using System;
using System.Collections.Generic;
using System.Text;
using DungeonsAndCodeWizards.Models.Characters;
using DungeonsAndCodeWizards.Models.Items;

namespace DungeonsAndCodeWizards.Contracts
{
    interface IAttackable
    {
        void Attack(Character character);
    }
}
