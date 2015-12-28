using EF_Code_First.Migrations;

namespace EF_Code_First
{
    using System.Data.Entity;

    public class MountainsContext : DbContext
    {
        public MountainsContext()
            : base("name=MountainsContext")
        {
        }

        public virtual DbSet<Country> Countries { get; set; }

        public virtual DbSet<Mountain> Mountains { get; set; }

        public virtual DbSet<Peak> Peaks { get; set; }

    }
}