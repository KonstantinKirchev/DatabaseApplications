using System;
using System.Linq;

namespace _1.EF_Mappings
{
    class Program
    {
        static void Main()
        {
            var context = new FootballExamEntities();
            var teams = context.Teams.Select(t => t.TeamName);

            foreach (var team in teams)
            {
                Console.WriteLine(team);
            }
        }
    }
}
