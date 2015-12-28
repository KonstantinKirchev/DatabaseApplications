using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace _6.EFCF_Phonebook.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<PhoneBookContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(PhoneBookContext context)
        {
            if (context.Channels.Any())
            {
                return;
            }
            AddUsers(context);

            AddChannels(context);

            AddChannelMessages(context);
        }

        private void AddUsers(PhoneBookContext context)
        {
            var users = new List<User>()
            {
                new User {UserName = "VGeorgiev", FullName = "Vladimir Georgiev", PhoneNumber = "0894545454"},
                new User {UserName = "Nakov", FullName = "Svetlin Nakov", PhoneNumber = "0897878787"},
                new User {UserName = "Ache", FullName = "Angel Georgiev", PhoneNumber = "0897121212"},
                new User {UserName = "Alex", FullName = "Alexandra Svilarova", PhoneNumber = "0894151417"},
                new User {UserName = "Petya", FullName = "Petya Grozdarska", PhoneNumber = "0895464646"}
            };

            foreach (var user in users)
            {
                context.Users.Add(user);
            }

            context.SaveChanges();
        }

        private void AddChannels(PhoneBookContext context)
        {
            var channels = new List<Channel>
            {
                new Channel {Name = "Malinki"},
                new Channel {Name = "SoftUni"},
                new Channel {Name = "Admins"},
                new Channel {Name = "Programmers"},
                new Channel {Name = "Geeks"},
            };

            foreach (var channel in channels)
            {
                context.Channels.Add(channel);
            }

            context.SaveChanges();
        }

        private void AddChannelMessages(PhoneBookContext context)
        {
            var channelMalinkiId = context.Channels.Where(x => x.Name == "Malinki").Select(x => x.Id).FirstOrDefault();
            var nakovId = context.Users.Where(x => x.UserName == "Nakov").Select(x => x.Id).FirstOrDefault();
            var vladoId = context.Users.Where(x => x.UserName == "VGeorgiev").Select(x => x.Id).FirstOrDefault();
            var petyaId = context.Users.Where(x => x.UserName == "Petya").Select(x => x.Id).FirstOrDefault();

            var channelMessages = new List<ChannelMessage>
            {
                new ChannelMessage { ChannelId = channelMalinkiId, Content = "Hey dudes, are you ready for tonight?", DateTime = DateTime.Now, UserId = petyaId },
                new ChannelMessage { ChannelId = channelMalinkiId, Content = "Hey Petya, this is the SoftUni chat.", DateTime = DateTime.Now, UserId = vladoId },
                new ChannelMessage { ChannelId = channelMalinkiId, Content = "Hahaha, we are ready!", DateTime = DateTime.Now, UserId = nakovId },
                new ChannelMessage { ChannelId = channelMalinkiId, Content = "Oh my god. I mean for drinking some beer!", DateTime = DateTime.Now, UserId = petyaId },
                new ChannelMessage { ChannelId = channelMalinkiId, Content = "We are sure!", DateTime = DateTime.Now, UserId = vladoId },
            };

            foreach (var channelMessage in channelMessages)
            {
                context.ChannelsMessages.Add(channelMessage);
            }

            context.SaveChanges();

        }
    }
}
