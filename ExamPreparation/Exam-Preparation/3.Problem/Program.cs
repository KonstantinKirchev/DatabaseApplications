using System.Linq;
using System.Xml.Linq;
using _1.Problem;

namespace _3.Problem
{
    class Program
    {
        static void Main()
        {
            var context = new GeographyEntities();
            var countries = context.Countries
                .OrderBy(c => c.CountryName)
                .Select(c => new
                {
                    country = c.CountryName,
                    monastery = c.Monasteries
                    .OrderBy(m => m.Name)
                    .Select(m => new
                    {
                        m.Name
                    })
                })
                .ToList();

            var xmlRoot = new XElement("monasteries");

            foreach (var country in countries)
            {
                var countryXml = new XElement(("country"), new XAttribute("name", country.country));
                if (!country.monastery.Any())
                {
                    countryXml = null;
                }
               
                foreach (var monastery in country.monastery)
                {
                    countryXml.Add(new XElement("monastery", monastery.Name));
                }

                xmlRoot.Add(countryXml);
            }
            xmlRoot.Save("monasteries.xml");
        }
    }
}
