using System;
using System.Linq;

namespace _1.EFDatabaseFirst
{
    internal class Program
    {
        private static void Main()
        {
            var context = new PhotographySystemEntities();

            var manufacturer = context.Cameras
                .OrderBy(c => c.Manufacturer.Name + " " + c.Model)
                .Select(c => c.Manufacturer.Name + " " + c.Model)
                .ToList();
            
            Console.WriteLine(string.Join("\n",manufacturer));
        }
    }
}
