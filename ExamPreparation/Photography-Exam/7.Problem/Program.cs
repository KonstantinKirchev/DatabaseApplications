using System;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using Newtonsoft.Json.Linq;
using _6.Problem;

namespace _7.Problem
{
    class Program
    {
        static void Main()
        {
            var context = new ChatRoomContext();
  
            string text = File.ReadAllText("../../messages.json");

            JArray messages = JArray.Parse(text); // взимам си отделните обекти

            foreach (var message in messages) // вървя по всеки от обектите и взимам цялата информация
            {
                if (message["content"] == null) // проверявам дали съществува и ако не хвърлям грешка и преминавам на следващият обект
                {
                    Console.WriteLine("Error: Content is required");
                    continue;
                }

                if (message["recipient"] == null)
                {
                    Console.WriteLine("Error: Recipient is required");
                    continue;
                }
                
                if (message["sender"] == null)
                {
                    Console.WriteLine("Error: Sender is required");
                    continue;
                }

                var recipient = message["recipient"].ToString();
                var recipientId = context.Users // взимам idто на получателя
                    .Where(u => u.Username == recipient)
                    .Select(u => u.Id)
                    .FirstOrDefault();
                
                var sender = message["sender"].ToString();
                var senderId = context.Users // взимам idто на изпращача
                    .Where(u => u.Username == sender)
                    .Select(u => u.Id)
                    .FirstOrDefault();

                context.UserMessages.AddOrUpdate(new UserMessage() // добавям цялата получена информация в таблицата в базата
                {
                    Content = message["content"].ToString(),
                    DateTime = DateTime.Parse(message["datetime"].ToString()),
                    RecipientId = recipientId,
                    SenderId = senderId
                });

                context.SaveChanges();
                Console.WriteLine("Message \"{0}\" imported", message["content"]);
            }
        }
    }
}
