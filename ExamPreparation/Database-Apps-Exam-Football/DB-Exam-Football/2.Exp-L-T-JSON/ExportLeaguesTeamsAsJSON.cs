using System;
using System.IO;
using System.Linq;
using _1.EF_Mappings;
using System.Web.Script.Serialization;

namespace _2.Exp_L_T_JSON
{
    class ExportLeaguesTeamsAsJSON
    {
        static void Main()
        {
            var context = new FootballExamEntities();
            var leaguesQuery = context.Leagues
                .OrderBy(l => l.LeagueName)
                .Select(l => new
                {
                    leagueName = l.LeagueName,
                    teams = l.Teams
                    .OrderBy(t=>t.TeamName)
                    .Select(t=>t.TeamName)
                })
                .ToList();

            //foreach (var league in leaguesQuery)
            //{
            //    Console.WriteLine("--{0}",league.leagueName);
            //    foreach (var team in league.teams)
            //    {
            //        Console.WriteLine(team);
            //    }
            //}
            var json = new JavaScriptSerializer().Serialize(leaguesQuery);

            File.WriteAllText(@"leagues-and-teams.json", json);
        }
    }
}
