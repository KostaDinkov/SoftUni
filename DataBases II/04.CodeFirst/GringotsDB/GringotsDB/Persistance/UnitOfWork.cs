using GringotsDB.Core;
using GringotsDB.Core.Repository;
using GringotsDB.Persistance.Repositories;

namespace GringotsDB.Persistance
{
    class UnitOfWork : IUnitOfWork
    {
        private GringotsDB context;

        public UnitOfWork(GringotsDB context)
        {
            this.context = context;
            this.Users = new UserRepository(this.context);
            this.WizardDeposits = new WizardDepositRepository(this.context);
        }

        public IWizardDepositRepository WizardDeposits { get; }

        public IUserRepository Users { get; }

        public int Complete()
        {
            return this.context.SaveChanges();
        }

        public void Dispose()
        {
            this.context.Dispose();
        }
    }
}