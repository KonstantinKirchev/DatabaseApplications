using System.Data.Entity.Migrations;
using System.Linq;
using System.Net.NetworkInformation;

namespace EF_Code_First.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<MountainsContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(MountainsContext context)
        {
            if (! context.Countries.Any())
            {
                Country bulgaria = new Country() { Code = "BG", Name = "Bulgaria"};
                context.Countries.Add(bulgaria);
                Country germany = new Country() { Code = "DE", Name = "Germany"};
                context.Countries.Add(germany);

                Mountain pirin = new Mountain(){Name = "Pirin", Countries = {bulgaria}};
                context.Mountains.Add(pirin);
                Mountain rila = new Mountain() { Name = "Rila", Countries = {bulgaria}};
                context.Mountains.Add(rila);
                Mountain rhodopes = new Mountain() { Name = "Rhodopes", Countries = {bulgaria}};
                context.Mountains.Add(rhodopes);

                Peak musala = new Peak(){Name = "Musala", Elevation = 2925, Mountain = rila};
                context.Peaks.Add(musala);
                Peak malyovitsa = new Peak() { Name = "Malyovitsa", Elevation = 2729, Mountain = rila };
                context.Peaks.Add(malyovitsa);
                Peak vihren = new Peak() { Name = "Vihren", Elevation = 2914, Mountain = pirin };
                context.Peaks.Add(vihren);
                
                context.SaveChanges();
            }
            
        }
    }
}
