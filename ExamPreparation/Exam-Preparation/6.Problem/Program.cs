using System;
using System.Linq;

namespace _6.Problem
{
    class Program
    {
        static void Main()
        {
            var context = new GographyExamContext();
            var mountains = context.Mountains.Select(m => new
            {
                mountain = m.Name,
                country = m.Country.CountryName,
                peaks = m.Peaks.Select(p => p.Name)
            })
            .ToList();

            foreach (var mountain in mountains)
            {
                Console.WriteLine("Mountain: {0}",mountain.mountain);
                Console.WriteLine("Country: {0}",mountain.country);
                Console.WriteLine("Peaks: {0}", string.Join(", ",mountain.peaks.DefaultIfEmpty("no peaks")));
            }
        }
    }
}
