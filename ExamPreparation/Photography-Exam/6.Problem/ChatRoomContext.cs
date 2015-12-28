using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using _6.Problem.Migrations;

namespace _6.Problem
{
    public class ChatRoomContext : DbContext
    {
        public ChatRoomContext()
            : base("name=ChatRoomContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ChatRoomContext, Configuration>());
        }
        
        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Channel> Channels { get; set; }

        public virtual DbSet<ChannelMessage> ChannelMessages { get; set; }

        public virtual DbSet<UserMessage> UserMessages { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}