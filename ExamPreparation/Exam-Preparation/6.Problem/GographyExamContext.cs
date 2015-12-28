using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using _6.Problem.Migrations;

namespace _6.Problem
{
    public class GographyExamContext : DbContext
    {
       
        public GographyExamContext()
            : base("name=GographyExamContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<GographyExamContext, Configuration>());
        }

        public virtual DbSet<Country> Countries { get; set; }

        public virtual DbSet<Mountain> Mountains { get; set; }

        public virtual DbSet<Peak> Peaks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            base.OnModelCreating(modelBuilder);
        } 
    }
}