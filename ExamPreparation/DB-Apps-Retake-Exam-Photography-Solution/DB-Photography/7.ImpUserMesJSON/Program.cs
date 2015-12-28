using System;
using System.IO;
using Newtonsoft.Json.Linq;
using _6.EFCF_Phonebook;

namespace _7.ImpUserMesJSON
{
    class Program
    {
        static void Main()
        {
            var context = new PhoneBookContext();
            string text = File.ReadAllText("../../messages.json"); // Прочитам си файла и импортвам System.IO

            JArray messages = JArray.Parse(text); // Трябва да инсталирам JSON и да импортна Newtonsoft.Json.Linq

            foreach (JToken message in messages) // Така вървя по всеки обект от Jsonа и му взимам данните, проверявам ги за null и ги записвам в таблицата.
            {
                UserMessage dbMessage = new UserMessage();

                if (message["content"] == null)
                {
                    Console.WriteLine("Error: Content is required");
                    continue; // така спирам изпълнението на кода и преминавам на следващият обект от Jsona
                }

                dbMessage.Content = message["content"].ToString();

                if (message["datetime"] == null)
                {
                    Console.WriteLine("Error: Datetime is required");
                    continue; // така спирам изпълнението на кода и преминавам на следващият обект от Jsona
                }

                dbMessage.DateTime = DateTime.Parse(message["datetime"].ToString());

                if (message["recipient"] == null)
                {
                    Console.WriteLine("Error: Recipient is required");
                    continue; // така спирам изпълнението на кода и преминавам на следващият обект от Jsona
                }

                dbMessage.Recipient.UserName = message["recipient"].ToString();

                if (message["sender"] == null)
                {
                    Console.WriteLine("Error: Sender is required");
                    continue; // така спирам изпълнението на кода и преминавам на следващият обект от Jsona
                }

                dbMessage.Sender.UserName = message["sender"].ToString();
                //if (message["phones"] != null)
                //{
                //    foreach (var phone in message["phones"])
                //    {
                //        dbMessage.Phones.Add(new Phone() { PhoneNumber = phone.ToString() }); // Тука правя каскадно добавяне на телефоните едновременно в Contact и Phone
                //    }
                //}

                //if (message["emails"] != null)
                //{
                //    foreach (var email in message["emails"])
                //    {
                //        dbMessage.Emails.Add(new Email() { EmailAddress = email.ToString() }); // Тука правя каскадно добавяне на телефоните едновременно в Contact и Email
                //    }
                //}
                //if (message["company"] != null)
                //{
                //    dbMessage.Company = message["company"].ToString();
                //}
                //if (message["notes"] != null)
                //{
                //    dbMessage.Notes = message["notes"].ToString();
                //}
                //if (message["position"] != null)
                //{
                //    dbMessage.Position = message["position"].ToString();
                //}
                //if (message["siteUrl"] != null)
                //{
                //    dbMessage.SiteUrl = message["siteUrl"].ToString();
                //}

                context.UserMessages.Add(dbMessage); // Добавям данните в таблицата Contacts
                context.SaveChanges(); // Запазвам промените по таблицата

                Console.WriteLine("Message {0} imported", dbMessage.Content);
            }
        }
    }
}
