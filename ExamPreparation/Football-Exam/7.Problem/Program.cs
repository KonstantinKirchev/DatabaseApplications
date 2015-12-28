using System;
using System.Data.Entity.Migrations;
using System.IO;
using Newtonsoft.Json.Linq;
using _6.Problem;

namespace _7.Problem
{
    class Program
    {
        private static void Main()
        {
            var context = new PhoneBookContext();

            string text = File.ReadAllText("../../contacts.json");

            JArray contacts = JArray.Parse(text); // взимам си отделните обекти

            foreach (JToken contact in contacts) // вървя по всеки от обектите и взимам цялата информация
            {
                Contact dbContact = new Contact();

                if (contact["name"] == null)  // проверявам дали съществува и ако не хвърлям грешка и преминавам на следващият обект
                {
                    Console.WriteLine("Error: Name is required");
                    continue;
                }
                dbContact.Name = contact["name"].ToString();

                if (contact["company"] != null)
                {
                    dbContact.Company = contact["company"].ToString();
                }
                if (contact["position"] != null)
                {
                    dbContact.Position = contact["position"].ToString();
                }
                if (contact["site"] != null)
                {
                    dbContact.SiteUrl = contact["site"].ToString();
                }
                if (contact["notes"] != null)
                {
                    dbContact.Notes = contact["notes"].ToString();
                }
                if (contact["phones"] != null)
                {
                    foreach (var phone in contact["phones"])
                    {
                        dbContact.Phones.Add(new Phone(){ PhoneNumber = phone.ToString() });
                    }
                }
                if (contact["emails"] != null)
                {
                    foreach (var email in contact["emails"])
                    {
                        dbContact.Emails.Add(new Email() {EmailAddress = email.ToString()});
                    }
                }
                
                context.Contacts.AddOrUpdate(dbContact);
                context.SaveChanges();

                Console.WriteLine("Contact {0} imported", dbContact.Name);
            }
        }
    }
}
