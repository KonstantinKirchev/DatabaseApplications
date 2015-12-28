using System;
using System.Globalization;
using System.Linq;

namespace _6.EFCF_Phonebook
{
    class EFCodeFirstPhonebook
    {
        static void Main()
        {
            var context = new PhoneBookContext();
            var channels = context.Channels
                .Select(c=> new
                {
                    c.Name,
                    Channel = c.ChannelMessages.Select(cm => new
                    {
                        cm.Content,
                        Date = cm.DateTime,
                        User = cm.User.UserName
                    })
                });

            foreach (var channel in channels)
            {
                Console.WriteLine(channel.Name);
                Console.WriteLine("-- Messages: --");
                foreach (var chan in channel.Channel)
                {
                    Console.WriteLine("Content: {0}, DateTime: {1}, User: {2}", chan.Content, chan.Date.ToString(new CultureInfo("en-US")), chan.User);
                }
            }
        }
    }
}
