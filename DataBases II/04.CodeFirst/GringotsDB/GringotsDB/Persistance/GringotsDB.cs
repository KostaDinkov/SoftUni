using System.Data.Entity;
using GringotsDB.Core.Models;
using GringotsDB.Persistance.EntityConfigurations;

namespace GringotsDB.Persistance
{
    public class GringotsDB : DbContext
    {
        public GringotsDB()
            : base("name=GringotsDB")
        {
        }
        
        public virtual DbSet<WizardDeposit> WizardDeposits { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new WizardDepositsConfiguration());
        }
    }
}