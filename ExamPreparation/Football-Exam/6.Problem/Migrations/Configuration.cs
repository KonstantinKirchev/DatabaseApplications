using System.Data.Entity.Migrations;
using System.Linq;

namespace _6.Problem.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<PhoneBookContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(PhoneBookContext context)
        {
            if (context.Contacts.Any())
            {
                return;
            }
            context.Contacts.AddOrUpdate(new Contact()
            {
                Name = "Peter Ivanov",
                Position = "CTO",
                Company = "Smart Ideas",
                SiteUrl = "http://blog.peter.com",
                Notes = "Friend from school",
                Emails = new Email[]
                {
                    new Email {EmailAddress = "peter@gmail.com"},
                    new Email {EmailAddress = "peter_ivanov@yahoo.com"}
                },
                Phones = new Phone[]
                {
                    new Phone {PhoneNumber = "+359 2 22 22 22"},
                    new Phone {PhoneNumber = "+359 88 77 88 99"},
                },
            });

            context.Contacts.Add(new Contact()
            {
                Name = "Maria",
                Phones = new Phone[]
                {
                    new Phone {PhoneNumber = "+359 22 33 44 55"}, 
                }
            });

            context.Contacts.Add(new Contact()
            {
                Name = "Angie Stanton",
                Emails = new Email[]
                {
                    new Email {EmailAddress = "info@angiestanton.com"},
                },
                SiteUrl = "http://angiestanton.com"
            });

            context.SaveChanges();
        }
    }
}
