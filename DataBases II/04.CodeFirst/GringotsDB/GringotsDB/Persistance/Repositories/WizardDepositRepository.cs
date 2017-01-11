using GringotsDB.Core.Models;
using GringotsDB.Core.Repository;

namespace GringotsDB.Persistance.Repositories
{
    class WizardDepositRepository : Repository<WizardDeposit>, IWizardDepositRepository
    {
        public WizardDepositRepository(GringotsDB context) : base(context)
        {
        }
    }
}