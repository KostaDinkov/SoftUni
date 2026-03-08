using BakerySystem.Domain.Common;
using Microsoft.EntityFrameworkCore;
using BakerySystem.Domain.Vendors;
using BakerySystem.Domain.Materials;

namespace BakerySystem.Infrastructure.Persistence;

public class BakeryDbContext(DbContextOptions<BakeryDbContext> options) : DbContext(options)
{
    public DbSet<Vendor> Vendors => Set<Vendor>();
    public DbSet<Material> Materials => Set<Material>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (var entityType in modelBuilder.Model.GetEntityTypes()
                     .Where(e => typeof(Entity).IsAssignableFrom(e.ClrType)))
        {
            modelBuilder.Entity(entityType.ClrType)
                .Ignore(nameof(Entity.DomainEvents));
        }
        modelBuilder.Entity<Vendor>(entity =>
        {
            entity.OwnsOne(v => v.ContactInfo);
            entity.OwnsOne(v => v.LegalInfo);
            entity.OwnsOne(v => v.BankingInfo);
        });
        base.OnModelCreating(modelBuilder);
    }
    
    public Task<int> SharedSaveChangesAsync(CancellationToken ct) => base.SaveChangesAsync(ct);
}

