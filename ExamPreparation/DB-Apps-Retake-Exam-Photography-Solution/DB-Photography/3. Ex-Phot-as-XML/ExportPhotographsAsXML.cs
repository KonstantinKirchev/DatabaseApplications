using System.Linq;
using System.Xml.Linq;
using _1.EF_Mapping;

namespace _3.Ex_Phot_as_XML
{
    class ExportPhotographsAsXML
    {
        static void Main()
        {
            var context = new PhotographySystemEntities();

            var photographQuery =
                context.Photographs
                .OrderBy(p => p.Title)
                .Select(p => new
                {
                    title = p.Title,
                    category = p.Category,
                    link = p.Link,
                    camera = p.Equipment.Camera.Manufacturer.Name + " " + p.Equipment.Camera.Model,
                    lens = p.Equipment.Camera.Manufacturer.Name + " " + p.Equipment.Lens.Model,
                    megapixels = p.Equipment.Camera.Megapixels,
                    price = p.Equipment.Lens.Price
                })
                .ToList();

            var xmlRoot = new XElement("photographs");

            foreach (var photograph in photographQuery)
            {
                var photographXml =
                    new XElement("photograph", new XAttribute("title", photograph.title),
                        new XElement("category", photograph.category.Name),
                        new XElement("link", photograph.link),
                        new XElement("equipment",
                            new XElement("camera", photograph.camera, new XAttribute("megapixels", photograph.megapixels.Value)),
                            photograph.price.HasValue ? 
                            new XElement("lens", photograph.lens, new XAttribute("price", string.Format("{0:f2}",photograph.price))) :
                            new XElement("lens",photograph.lens)));

                xmlRoot.Add(photographXml);
            }
            xmlRoot.Save("photographs.xml");
        }
    }
}
