using System;
using System.Linq;

namespace _6.CodeFirstPhonebook
{
    class CodeFirstPhonebook
    {
        static void Main()
        {
            var context = new PhonebookContext();
            var contacts = context.Contacts
                .Select(c => new
                {
                    ContactName = c.Name,
                    ContactPhone = c.Phones.Select(p => p.PhoneNumber),
                    ContactEmail = c.Emails.Select(e => e.EmailAddress)
                })
                .ToList();

            foreach (var contact in contacts)
            {
                Console.WriteLine("ContactName: {0}",contact.ContactName);
                Console.WriteLine("Phones: {0}",contact.ContactPhone.Any() ? string.Join(", ",contact.ContactPhone) : "no phone");
                Console.WriteLine("Emails: {0}",contact.ContactEmail.Any() ? string.Join(", ", contact.ContactEmail) : "no email");
            }
        }
    }
}
