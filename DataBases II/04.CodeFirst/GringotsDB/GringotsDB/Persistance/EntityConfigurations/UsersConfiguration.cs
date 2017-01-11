using System.Data.Entity.ModelConfiguration;
using GringotsDB.Core.Models;

namespace GringotsDB.Persistance.EntityConfigurations
{
    class UsersConfiguration : EntityTypeConfiguration<User>

    {
        public UsersConfiguration()
        {
            this.Property(p => p.UserName).HasMaxLength(30);
            this.Property(p => p.Password).HasMaxLength(50);
            this.Property(p => p.ProfilePicture).HasMaxLength(1024);
        }
    }
}