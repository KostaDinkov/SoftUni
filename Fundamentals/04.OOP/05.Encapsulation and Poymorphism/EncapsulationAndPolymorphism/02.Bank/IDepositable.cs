using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02.Bank
{
    public interface IDepositable
    {
        void Deposit(decimal amount);
    }
}