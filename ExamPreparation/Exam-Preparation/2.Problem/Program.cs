using System.IO;
using System.Linq;
using System.Web.Script.Serialization;
using _1.Problem;

namespace _2.Problem
{
    class Program
    {
        static void Main()
        {
            var context = new GeographyEntities();

            var rivers = context.Rivers
                .OrderByDescending(r => r.Length)
                .Select(r => new
            {
                riverName = r.RiverName,
                riverLength = r.Length,
                countries = r.Countries
                .OrderBy(c => c.CountryName)
                .Select(c =>  c.CountryName)
            });

            var json = new JavaScriptSerializer().Serialize(rivers);
            File.WriteAllText(@"rivers.json", json);
        }
    }
}
