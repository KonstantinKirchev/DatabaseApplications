using System;
using System.Linq;

namespace _1.Problem
{
    class Program
    {
        static void Main()
        {
            var context = new GeographyEntities();
            var continents = context.Continents.Select(c => c.ContinentName).ToList();
            Console.WriteLine(string.Join("\n",continents));
        }
    }
}
