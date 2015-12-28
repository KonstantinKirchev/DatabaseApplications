using System;
using System.Linq;

namespace _1.Problem
{
    class Program
    {
        static void Main()
        {
            var context = new FootballExamEntities();
            var teams = context.Teams.Select(t => t.TeamName);
            Console.WriteLine(string.Join("\n",teams));
        }
    }
}
