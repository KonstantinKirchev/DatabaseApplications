using System.Data.Entity.ModelConfiguration.Conventions;
using _5.Problem.Migrations;

namespace _5.Problem
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class MoviesContext : DbContext
    {
        public MoviesContext()
            : base("name=MoviesContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MoviesContext, Configuration>());
        }

        public virtual DbSet<Country> Countries { get; set; }
        
        public virtual DbSet<User> Users { get; set; }
        
        public virtual DbSet<Movie> Movies { get; set; }
        
        public virtual DbSet<Rating> Raitings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}