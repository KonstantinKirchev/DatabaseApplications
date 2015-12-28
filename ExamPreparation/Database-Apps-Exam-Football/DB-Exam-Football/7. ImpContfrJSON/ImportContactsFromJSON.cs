using System;
using System.IO;
using Newtonsoft.Json.Linq;
using _6.CodeFirstPhonebook;

namespace _7.ImpContfrJSON
{
    class ImportContactsFromJSON
    {
        static void Main()
        {
            var context = new PhonebookContext();
            string text = File.ReadAllText("../../contacts.json"); // Прочитам си файла и импортвам System.IO

            JArray contacts = JArray.Parse(text); // Трябва да инсталирам JSON и да импортна Newtonsoft.Json.Linq

            foreach (JToken contact in contacts) // Така вървя по всеки обект от Jsonа и му взимам данните, проверявам ги за null и ги записвам в таблицата.
            {
                Contact dbContact = new Contact(); // създавам си нов контакт който ще пълня

                if (contact["name"] == null)
                {
                    Console.WriteLine("Error: Name is required");
                    continue; // така спирам изпълнението на кода и преминавам на следващият обект от Jsona
                }

                dbContact.Name = contact["name"].ToString();

                if (contact["phones"] != null)
                {
                    foreach (var phone in contact["phones"])
                    {
                        dbContact.Phones.Add(new Phone() { PhoneNumber = phone.ToString() }); // Тука правя каскадно добавяне на телефоните едновременно в Contact и Phone
                    }
                }
                
                if (contact["emails"] != null)
                {
                    foreach (var email in contact["emails"])
                    {
                        dbContact.Emails.Add(new Email() { EmailAddress = email.ToString() }); // Тука правя каскадно добавяне на телефоните едновременно в Contact и Email
                    }
                }
                if (contact["company"] != null)
                {
                    dbContact.Company = contact["company"].ToString();    
                }
                if (contact["notes"] != null)
                {
                    dbContact.Notes = contact["notes"].ToString();
                }
                if (contact["position"] != null)
                {
                    dbContact.Position = contact["position"].ToString();
                }
                if (contact["siteUrl"] != null)
                {
                    dbContact.SiteUrl = contact["siteUrl"].ToString();
                }

                context.Contacts.Add(dbContact); // Добавям данните в таблицата Contacts
                context.SaveChanges(); // Запазвам промените по таблицата

                Console.WriteLine("Contact {0} imported", dbContact.Name);
            }
        }
    }
}
