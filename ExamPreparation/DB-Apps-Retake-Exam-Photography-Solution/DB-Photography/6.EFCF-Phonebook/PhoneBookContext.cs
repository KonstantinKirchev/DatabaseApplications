using System.Data.Entity.ModelConfiguration.Conventions;
using _6.EFCF_Phonebook.Migrations;

namespace _6.EFCF_Phonebook
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

        public virtual DbSet<Channel> Channels { get; set; }

        public virtual DbSet<ChannelMessage> ChannelsMessages { get; set; }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<UserMessage> UserMessages { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<UserMessage>()
            //    .HasRequired(x => x.Sender)
            //    .WithMany(x => x.SentUserMessages)
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<UserMessage>()
            //    .HasRequired(x => x.Recipient)
            //    .WithMany(x => x.RecievedUserMessages)
            //    .WillCascadeOnDelete(false);
            
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }

}