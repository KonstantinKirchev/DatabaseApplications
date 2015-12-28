using System;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Xml.Linq;
using _1.EF_Mapping;

namespace _4.ImpManLenfrXML
{
    class Program
    {
        static void Main()
        {
            var context = new PhotographySystemEntities();

            var xmlDoc = XDocument.Load("../../manufacturers-and-lenses.xml");

            var manufacturerElements = xmlDoc.Root.Elements(); // взимам всички елементи

            int index = 1;

            foreach (var manufacturerElement in manufacturerElements) // вървя по външните елементи
            {
                var manufacturerEntity = new Manufacturer(); // създавам си нов обект

                manufacturerEntity.Name = manufacturerElement.Element("manufacturer-name").Value; // и почвам да го пълня

                Console.WriteLine("Processing manufacturer #{0} ...", index++);

                if (context.Manufacturers.Any(m => m.Name == manufacturerEntity.Name)) // проверявам дали съществува обект с такова име
                {
                    Console.WriteLine("Existing manufacturer: {0}", manufacturerEntity.Name);
                }
                else
                {
                    context.Manufacturers.AddOrUpdate(manufacturerEntity); // ако не съществъва в базата го добавям в базата
                    Console.WriteLine("Created manufacturer: {0}", manufacturerEntity.Name);
                }

                if (manufacturerElement.Element("lenses") != null) // проверям дали съществува такъв елемент, защото по условия е optional
                {
                    foreach (var lensElement in manufacturerElement.Element("lenses").Elements()) // вървя по вътрешните елементи
                    {
                        if (lensElement != null) // проверявам дали съществува такъв елемент, защото по условие е optional
                        {
                            var lensEntity = new Lens(); // създавам си нов обект

                            lensEntity.Type = lensElement.Attribute("type").Value; // и почвам да го пълня

                            if (lensElement.Attribute("price") != null) // проверявам дали съществува такъв атрибут, защото по условие е optional
                            {
                                lensEntity.Price = decimal.Parse(lensElement.Attribute("price").Value); // пълня обекта
                            }

                            lensEntity.Model = lensElement.Attribute("model").Value; // пълня обекта

                            if (context.Lenses.Any(l => l.Model == lensEntity.Model)) // проверявам дали съществува такъв модел лещи в базата
                            {
                                Console.WriteLine("Existing lens: {0}", lensEntity.Model);
                            }
                            else
                            {
                                context.Lenses.AddOrUpdate(lensEntity); // и ако не съществува го добавям целията обект в базата
                                Console.WriteLine("Created lens: {0}", lensEntity.Model);
                            }
                        }
                    }
                }
                Console.WriteLine();
            }
            context.SaveChanges(); // на края запазвам промените в базата
        }
    }
}
