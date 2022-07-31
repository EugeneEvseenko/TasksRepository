using EFCoreExample.Entity;
using Microsoft.EntityFrameworkCore;

namespace EFCoreExample.Core
{
    public class AppContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public AppContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=Skillfactory_test;Trusted_Connection=True;Encrypt=False;");
        }
    }
}
