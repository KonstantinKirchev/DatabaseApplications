using System;

namespace EF_Mappings
{
    class ListContinents
    {
        static void Main()
        {
            var context = new GeographyEntities();
            foreach (var c in context.Continents)
            {
                Console.WriteLine(c.ContinentName);
            }
        }
    }
}
