using Microsoft.EntityFrameworkCore;
using BakerySystem.Domain;

namespace BakerySystem.Infrastructure.Persistence;

public class BakeryDbContext: DbContext
{
    public BakeryDbContext(DbContextOptions<BakeryDbContext> options) : base(options)
    {
    }

    public DbSet<Vendor> Vendors => Set<Vendor>();
    public Task<int> SharedSaveChangesAsync(CancellationToken ct) => base.SaveChangesAsync(ct);
}

