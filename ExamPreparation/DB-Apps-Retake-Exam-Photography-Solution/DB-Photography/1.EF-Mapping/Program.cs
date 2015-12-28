using System;
using System.Linq;

namespace _1.EF_Mapping
{
    class Program
    {
        static void Main()
        {
            var context = new PhotographySystemEntities();

            var cameras = context.Cameras
                .Select(x => x.Manufacturer.Name +" "+ x.Model)
                .OrderBy(x => x)
                .ToList();

            Console.WriteLine(string.Join("\n",cameras));
        }
    }
}
