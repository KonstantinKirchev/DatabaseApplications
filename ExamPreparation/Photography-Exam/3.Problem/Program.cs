using System.Linq;
using System.Xml.Linq;
using _1.EFDatabaseFirst;

namespace _3.Problem
{
    class Program
    {
        static void Main()
        {
            var context = new PhotographySystemEntities();

            var photographs = context.Photographs
                .OrderBy(p => p.Title)
                .Select(p => new
                {
                    title = p.Title,
                    category = p.Category.Name,
                    link = p.Link,
                    megapixels = p.Equipment.Camera.Megapixels,
                    camera = p.Equipment.Camera.Manufacturer.Name + " " + p.Equipment.Camera.Model,
                    lens = p.Equipment.Camera.Manufacturer.Name + " " + p.Equipment.Lens.Model,
                    price = p.Equipment.Lens.Price
                });

            var xmlRoot = new XElement("photographs");

            foreach (var photograph in photographs)
            {
                var photographXml =
                    new XElement(("photograph"), new XAttribute("title", photograph.title),
                    new XElement("category",photograph.category),
                    new XElement("link", photograph.link),
                    new XElement("equipment",
                    new XElement("camera", photograph.camera, new XAttribute("megapixels", photograph.megapixels)),
                    photograph.price != null
                        ? new XElement("lens", photograph.lens,
                            new XAttribute("price", string.Format("{0:f2}", photograph.price)))
                        : new XElement("lens", photograph.lens)));
                
                xmlRoot.Add(photographXml);
            }
            xmlRoot.Save("photographs.xml");
        }
    }
}
