using System;
using System.IO;
using System.Linq;
using Newtonsoft.Json.Linq;
using _6.EFCF_Phonebook;

namespace _8.ImpUserMesJSON
{
    class Program
    {
        static void Main()
        {
            var context = new PhoneBookContext();
            string text = File.ReadAllText("../../messages.json");

            JArray messages = JArray.Parse(text); // взимам си отделните обекти

            foreach (JToken message in messages) // вървя по всеки от обектите и взимам цялата информация
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
                
                var username = message["recipient"].ToString();

                var recipientId = context.Users // взимам idто на получателя
                .Where(x => x.UserName == username)
                .Select(x => x.Id)
                .FirstOrDefault();

                var senderUsername = message["sender"].ToString();

                var senderId = context.Users // взимам idто на изпращача
                    .Where(x => x.UserName == senderUsername)
                    .Select(x => x.Id)
                    .FirstOrDefault();

                var newMessage = new UserMessage // добавям цялата получена информация в таблицата в базата
                {
                    Content = message["content"].ToString(),
                    DateTime = DateTime.Parse(message["datetime"].ToString()),
                    RecipientId = recipientId,
                    SenderId = senderId
                };

                context.UserMessages.Add(newMessage); 
                context.SaveChanges(); 

                Console.WriteLine("Message \"{0}\" imported", newMessage.Content);
            }
        }
    }
}
