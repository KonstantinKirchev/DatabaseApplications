using System;
using System.IO;
using EF_Code_First;
using Newtonsoft.Json.Linq;

namespace Import_Mountains
{
    class ImportMountains
    {
        static void Main()
        {
            var context = new MountainsContext();

            string text = File.ReadAllText("../../mountains.json"); // Прочитам си файла и импортвам System.IO

            JArray mountains = JArray.Parse(text); // Трябва да инсталирам JSON и да импортна Newtonsoft.Json.Linq

            foreach (JToken mountain in mountains) // Така вървя по всеки обект от Jsonа и му взимам данните, проверявам ги за null и ги записвам в таблицата.
            {
                Mountain dbMountain = new Mountain();

                if (mountain["mountainName"] == null)
                {
                    Console.WriteLine("Error: Missing mountain name");
                    continue; // така спирам изпълнението на кода и преминавам на следващият обект от Jsona
                }
                
                bool noPeakNamenoElevation = false;
                
                dbMountain.Name = mountain["mountainName"].ToString();

                if (mountain["peaks"] != null)
                {
                    foreach (var peak in mountain["peaks"])
                    {
                        if (peak["peakName"] == null)
                        {
                            Console.WriteLine("Error: Missing peak name");
                            noPeakNamenoElevation = true;
                            break;
                        }
                        if (peak["elevation"] == null)
                        {
                            Console.WriteLine("Error: Missing peak elevation");
                            noPeakNamenoElevation = true;
                            break;
                        }
                        dbMountain.Peaks.Add(new Peak() { Name = peak["peakName"].ToString(), Elevation = int.Parse(peak["elevation"].ToString())}); // Тука правя каскадно добавяне на телефоните едновременно в Contact и Phone
                    }
                }

                if (mountain["countries"] != null)
                {
                    foreach (var country in mountain["countries"])
                    {
                        var countryCode = country.ToString().Substring(0,2).ToUpper();
                        dbMountain.Countries.Add(new Country() { Name = country.ToString(), Code = countryCode}); // Тука правя каскадно добавяне на телефоните едновременно в Contact и Email
                    }
                }


                if (!noPeakNamenoElevation)
                {
                    context.Mountains.Add(dbMountain); // Добавям данните в таблицата Contacts
                    context.SaveChanges(); // Запазвам промените по таблицата
                    Console.WriteLine("Mountain {0} imported", dbMountain.Name);
                }          
            }
        }
    }
}
