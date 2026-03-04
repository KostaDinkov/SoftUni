using Microsoft.EntityFrameworkCore;
using BakerySystem.Domain;

namespace BakerySystem.Infrastructure.Persistence;

public class BakeryDbContext(DbContextOptions<BakeryDbContext> options) : DbContext(options)
{
    public DbSet<Vendor> Vendors => Set<Vendor>();
    public DbSet<Material> Materials => Set<Material>();
    
    public Task<int> SharedSaveChangesAsync(CancellationToken ct) => base.SaveChangesAsync(ct);
}

