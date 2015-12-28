using System.Data.Entity.ModelConfiguration.Conventions;
using _6.Problem.Migrations;

namespace _6.Problem
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class PhoneBookContext : DbContext
    {
        public PhoneBookContext()
            : base("name=PhoneBookContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<PhoneBookContext, Configuration>());
        }

        public virtual DbSet<Email> Emails { get; set; }

        public virtual DbSet<Phone> Phones { get; set; }

        public virtual DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }

}