using System;
using System.IO;
using Newtonsoft.Json.Linq;
using _6.Problem;

namespace _7.Problem
{
    class Program
    {
        static void Main()
        {
            var context = new GographyExamContext();
            string text = File.ReadAllText("../../mountains.json"); // Прочитам си файла и импортвам System.IO

            JArray mountains = JArray.Parse(text); // Трябва да инсталирам JSON и да импортна Newtonsoft.Json.Linq

            foreach (JToken mountain in mountains) // Така вървя по всеки обект от Jsonа и му взимам данните, проверявам ги за null и ги записвам в таблицата.
            {
                Mountain dbMountain = new Mountain(); // създавам си нов контакт който ще пълня

                if (mountain["mountainName"] == null)
                {
                    Console.WriteLine("Error: Missing mountain name");
                    continue; // така спирам изпълнението на кода и преминавам на следващият обект от Jsona
                }

                dbMountain.Name = mountain["mountainName"].ToString();

                bool isMissing = false;

                if (mountain["peaks"] != null)
                {
                    foreach (var peaks in mountain["peaks"])
                    {
                        if (peaks["peakName"] != null && peaks["elevaton"] != null)
                        {
                            dbMountain.Peaks.Add(new Peak() { Name = peaks["peakName"].ToString(), Elevation = int.Parse(peaks["elevation"].ToString()) });
                        }
                        else if (peaks["peakName"] == null)
                        {
                            Console.WriteLine("Error: Missing peak name");
                            isMissing = true;
                        }
                        else if (peaks["elevation"] == null)
                        {
                            Console.WriteLine("Error: Missing peak elevation");
                            isMissing = true;
                        }
                    }
                }

                context.Mountains.Add(dbMountain); // Добавям данните в таблицата Contacts
                context.SaveChanges(); // Запазвам промените по таблицата
                
                if (!isMissing)
                {
                    Console.WriteLine("Mountain {0} imported", dbMountain.Name);    
                }
                
            }
        }
    }
}
