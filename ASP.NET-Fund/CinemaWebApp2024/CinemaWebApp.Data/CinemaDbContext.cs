using CinemaWebApp.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaWebApp.Data
{
    public class CinemaDbContext: DbContext
    {
        public CinemaDbContext(DbContextOptions<CinemaDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Movie> Movies { get; set; } = null!;

    }
}
