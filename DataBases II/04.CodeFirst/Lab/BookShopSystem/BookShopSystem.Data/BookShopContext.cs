using System.Data.Entity;
using Models;

namespace BookShopSystem.Data
{
    public class BookShopContext : DbContext
    {
        public BookShopContext()
            : base("name=BookShopContext")
        {
            Database.SetInitializer(new BookShopDBInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                        .HasMany(b => b.RelatedBooks)
                        .WithMany()
                        .Map(m =>
                             {
                                 m.MapLeftKey("BookId");
                                 m.MapRightKey("RelatedId");
                                 m.ToTable("RelatedBooks");
                             });
        }

        public virtual DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}