using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace _6.Problem.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<ChatRoomContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ChatRoomContext context)
        {
            if (context.Channels.Any())
            {
                return;
            }
            AddUsers(context);
            AddChannels(context);
            AddChannelMessages(context);
        }

        private void AddChannelMessages(ChatRoomContext context)
        {
            var channelId = context.Channels.Where(ch => ch.Name == "Malinki").Select(ch => ch.Id).FirstOrDefault();
            var nakovId = context.Users.Where(u => u.Username == "Nakov").Select(u => u.Id).FirstOrDefault();
            var petyaId = context.Users.Where(u => u.Username == "Petya").Select(u => u.Id).FirstOrDefault();
            var vGeorgievId = context.Users.Where(u => u.Username == "VGeorgiev").Select(u => u.Id).FirstOrDefault();
            
            var channelMessages = new List<ChannelMessage>()
            {
                new ChannelMessage {ChannelId = channelId, Content = "Hey dudes, are you ready for tonight?", DateTime = DateTime.Now, UserId = petyaId},
                new ChannelMessage {ChannelId = channelId, Content = "Hey Petya, this is the SoftUni chat.", DateTime = DateTime.Now, UserId = vGeorgievId},
                new ChannelMessage {ChannelId = channelId, Content = "Hahaha, we are ready!", DateTime = DateTime.Now, UserId = nakovId},
                new ChannelMessage {ChannelId = channelId, Content = "Oh my god. I mean for drinking beers!", DateTime = DateTime.Now, UserId = petyaId},
                new ChannelMessage {ChannelId = channelId, Content = "We are sure!", DateTime = DateTime.Now, UserId = vGeorgievId}
                
            };

            foreach (var channelMessage in channelMessages)
            {
                context.ChannelMessages.AddOrUpdate(channelMessage);
            }

            context.SaveChanges();
        }

        private void AddChannels(ChatRoomContext context)
        {
            var channels = new List<Channel>()
            {
                new Channel { Name = "Malinki" },
                new Channel { Name = "SoftUni" },
                new Channel { Name = "Admins" },
                new Channel { Name = "Programmers" },
                new Channel { Name = "Geeks" },
            };

            foreach (var channel in channels)
            {
                context.Channels.AddOrUpdate(channel);
            }

            context.SaveChanges();
        }

        private void AddUsers(ChatRoomContext context)
        {
            var users = new List<User>()
            {
                new User {Username= "VGeorgiev", Fullname= "Vladimir Georgiev", PhoneNumber= "0894545454"},
                new User {Username= "Nakov", Fullname= "Svetlin Nakov", PhoneNumber= "0897878787"},
                new User {Username= "Ache", Fullname= "Angel Georgiev", PhoneNumber= "0897121212"},
                new User {Username= "Alex", Fullname= "Alexandra Svilarova", PhoneNumber= "0894151417"},
                new User {Username= "Petya", Fullname= "Petya Grozdarska", PhoneNumber= "0895464646"}
            };

            foreach (var user in users)
            {
                context.Users.AddOrUpdate(user);
            }

            context.SaveChanges();
        }
    }
}
