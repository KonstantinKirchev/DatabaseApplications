using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using BookShopSystem.Data.Migrations;
using BookShopSystem.Models;

namespace BookShopSystem.Data
{
    public class BookShopContext : DbContext
    {
       
        public BookShopContext()
            : base("name=BookShopContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BookShopContext,Configuration>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove(new OneToManyCascadeDeleteConvention());

            //modelBuilder.Entity<Book>()
            //    .HasMany(a=>a.Categories)
            //    .WithOptional();

            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Book> Books { get; set; }

        public virtual DbSet<Author> Authors { get; set; }

        public virtual DbSet<Category> Categories { get; set; }
    }
}