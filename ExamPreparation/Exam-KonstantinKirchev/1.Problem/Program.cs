using System;
using System.Linq;

namespace _1.Problem
{
    class Program
    {
        static void Main()
        {
            var context = new DiabloEntities();
            var characters = context.Characters
                .Select(c => c.Name)
                .ToList();
            Console.WriteLine(string.Join("\n",characters));
        }
    }
}
