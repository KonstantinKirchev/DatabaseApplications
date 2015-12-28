using System.IO;
using System.Linq;
using System.Web.Script.Serialization;
using _1.EFDatabaseFirst;

namespace _2.Problem
{
    class Program
    {
        static void Main()
        {
            var context = new PhotographySystemEntities();
            var manufacturers = context.Manufacturers
                .OrderBy(m => m.Name)
                .Select(m => new
                {
                   manufacturer =  m.Name,
                   cameras = m.Cameras
                   .OrderBy(c => c.Model)
                   .Select(c => new
                   {
                       model = c.Model,
                       price = c.Price
                   })
                })
                .ToList();

            var json = new JavaScriptSerializer().Serialize(manufacturers);

            File.WriteAllText(@"manufactureres-and-cameras.json", json);
            
        }
    }
}
