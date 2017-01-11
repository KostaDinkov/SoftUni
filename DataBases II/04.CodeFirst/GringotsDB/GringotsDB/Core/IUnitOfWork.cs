using System;
using GringotsDB.Core.Repository;

namespace GringotsDB.Core
{
    interface IUnitOfWork: IDisposable
    {
    IWizardDepositRepository WizardDeposits { get; }
    IUserRepository Users { get; }
    int Complete();
    }
}
