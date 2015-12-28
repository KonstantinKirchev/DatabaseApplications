using System;
using System.Linq;

namespace _6.Problem
{
    class Program
    {
        static void Main()
        {
            var context = new PhoneBookContext();
            var contacts = context.Contacts
                .Select(c => new
                {
                    contactName = c.Name,
                    phones = c.Phones.Select(p => p.PhoneNumber),
                    emails = c.Emails.Select(e => e.EmailAddress)
                });

            foreach (var contact in contacts)
            {
                Console.WriteLine("Contact name: {0}",contact.contactName);
                Console.WriteLine("Contact emails: {0}", string.Join(", ", contact.emails.DefaultIfEmpty("no emails")));
                Console.WriteLine("Contact phones: {0}", string.Join(", ", contact.phones.DefaultIfEmpty("no phones")));
                Console.WriteLine();
            }
        }
    }
}
