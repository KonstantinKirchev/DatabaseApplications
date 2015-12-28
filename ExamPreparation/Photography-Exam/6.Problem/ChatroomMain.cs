using System;
using System.Globalization;
using System.Linq;

namespace _6.Problem
{
    class ChatRoomMain
    {
        static void Main()
        {
            var context = new ChatRoomContext();
            var channels = context.Channels
                .Select(ch => new
                {
                    ChannelName = ch.Name,
                    ChannelMessage = ch.ChannelMessages
                    .Select(cm => new
                    {
                        cm.Content,
                        Date = cm.DateTime,
                        User = cm.User.Username
                    })
                });

            foreach (var channel in channels)
            {
                Console.WriteLine(channel.ChannelName);
                Console.WriteLine("-- Messages: --");
                foreach (var message in channel.ChannelMessage)
                {
                    Console.WriteLine("Content: {0}, DateTime: {1}, User: {2}", message.Content, message.Date.ToString(new CultureInfo("en-US")),message.User);
                }
            }
        }
    }
}
