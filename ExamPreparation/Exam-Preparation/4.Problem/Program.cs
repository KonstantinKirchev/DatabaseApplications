using System;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Xml.Linq;
using _1.Problem;

namespace _4.Problem
{
    class Program
    {
        static void Main()
        {
            var context = new GeographyEntities();

            var xmlDoc = XDocument.Load("../../rivers.xml");

            var riversElements = xmlDoc.Root.Elements(); // взимам всички елементи


            foreach (var riverElement in riversElements) // вървя по външните елементи
            {
                var riverEntity = new River(); // създавам си нов обект

                riverEntity.RiverName = riverElement.Element("name").Value; // и почвам да го пълня
                riverEntity.Length = int.Parse(riverElement.Element("length").Value);
                riverEntity.Outflow = riverElement.Element("outflow").Value;
                
                if (riverElement.Element("drainage-area") != null)
                {
                    riverEntity.DrainageArea = int.Parse(riverElement.Element("drainage-area").Value);
                }

                if (riverElement.Element("average-discharge") != null)
                {
                    riverEntity.AverageDischarge = int.Parse(riverElement.Element("average-discharge").Value);
                }

                if (riverElement.Element("countries") != null) // проверям дали съществува такъв елемент, защото по условия е optional
                {
                    foreach (var countryElement in riverElement.Element("countries").Elements()) // вървя по вътрешните елементи
                    {
                        if (countryElement != null) // проверявам дали съществува такъв елемент, защото по условие е optional
                        {
                            var country = countryElement.Value;
                            var countryEntity =
                                context.Countries.FirstOrDefault(c => c.CountryName == country);
                            if (countryEntity != null)
                            {
                                riverEntity.Countries.Add(countryEntity);
                            }
                            else
                            {
                                throw new Exception(string.Format("Cannot find country {0} in the DB", country));
                            }
                        }
                    }
                }
                context.Rivers.AddOrUpdate(riverEntity);              
            }
            context.SaveChanges(); // на края запазвам промените в базата
        }
    }
}
