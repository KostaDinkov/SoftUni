using System.Data.Entity.ModelConfiguration;
using GringotsDB.Core.Models;

namespace GringotsDB.Persistance.EntityConfigurations
{
    class WizardDepositsConfiguration : EntityTypeConfiguration<WizardDeposit>
    {
        public WizardDepositsConfiguration()
        {
            this.ToTable("WizardDeposits");

            this.HasKey(k => k.Id);

            this.Property(p => p.FirstName)
                .HasMaxLength(50);

            this.Property(p => p.LastName)
                .HasMaxLength(60)
                .IsRequired();

            this.Property(p => p.Notes)
                .HasMaxLength(1000);

            this.Property(p => p.MagicWandCreator)
                .HasMaxLength(100);

            this.Property(p => p.DepositGroup)
                .HasMaxLength(20);
        }
    }
}