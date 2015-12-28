using System;
using System.Linq;

namespace EF_Mappings
{
    class ListContinents
    {
        static void Main()
        {
            var context = new GeographyEntities();
            var continents = context.Continents.Select(c => c.ContinentName);

            foreach (var con in continents)
            {
                Console.WriteLine(con);
            }
        }
    }
}
