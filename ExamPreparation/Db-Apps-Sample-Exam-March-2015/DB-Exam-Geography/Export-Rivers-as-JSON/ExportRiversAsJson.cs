namespace Export_Rivers_as_JSON
{
    
    using System.Linq;
    using EF_Mappings;
    using System.Web.Script.Serialization;
    using System.IO;

    internal class ExportRiversAsJson
    {
        private static void Main()
        {
            var context = new GeographyEntities();
            var riversQuery = context.Rivers
                .OrderByDescending(r => r.Length)
                .Select(r => new
                {
                    riverName = r.RiverName,
                    riverLength = r.Length,
                    countries = r.Countries
                        .OrderBy(c => c.CountryName)
                        .Select(c => c.CountryName)
                })
                .ToList();

            var json = new JavaScriptSerializer().Serialize(riversQuery);

            File.WriteAllText(@"rivers.json", json);
        }
    }
}
