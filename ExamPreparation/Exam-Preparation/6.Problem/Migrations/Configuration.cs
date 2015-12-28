using System.Data.Entity.Migrations;

namespace _6.Problem.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<GographyExamContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(GographyExamContext context)
        {
            context.Countries.AddOrUpdate(new Country
            {
                CountryName = "Bulgaria",
                CountryCode = "BG",
                Mountains = new Mountain[]
                {
                    new Mountain {Name = "Rila", Peaks = new Peak[]
                    {
                        new Peak {Name = "Musala", Elevation = 2925},
                        new Peak {Name = "Malyovitsa", Elevation = 2729}
                    }},
                    new Mountain {Name = "Pirin", Peaks = new Peak[]
                    {
                        new Peak {Name = "Vihren", Elevation = 2914}
                    }},
                    new Mountain {Name = "Rhodopes"}
                }
            });
            context.Countries.AddOrUpdate(new Country { CountryName = "Germany", CountryCode = "GE"});

            context.SaveChanges();
        }
    }
}
