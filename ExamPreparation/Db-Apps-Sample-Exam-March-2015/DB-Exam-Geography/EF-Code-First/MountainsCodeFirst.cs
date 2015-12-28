using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using EF_Code_First.Migrations;

namespace EF_Code_First
{
    class MountainsCodeFirst
    {
        static void Main()
        {

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MountainsContext, Configuration>());
            
            var context = new MountainsContext();
            var mountain = context.Mountains
                .Select(m => new
                {
                    m.Name,
                    Countries = m.Countries.Select(c => c.Name),
                    Peaks = m.Peaks.Select(p => p.Name)
                })
                .ToList();

            foreach (var m in mountain)
            {
                Console.WriteLine("Mountain {0} in {1} with peaks {2}",m.Name,string.Join(", ",m.Countries),m.Peaks.Any() ? string.Join(", ",m.Peaks) : "none");
            }
        }
    }
}
