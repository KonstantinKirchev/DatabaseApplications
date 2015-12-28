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
            var context = new FootballExamEntities();

            var xmlDoc = XDocument.Load("../../leagues-and-teams.xml");

            var leagueElements = xmlDoc.Root.Elements(); // взимам всички елементи

            int index = 1;

            foreach (var leagueElement in leagueElements) // вървя по външните елементи
            {
                var leagueEntity = new League(); // създавам си нов обект

                Console.WriteLine("Processing league #{0} ...", index++);

                if (leagueElement.Element("league-name") != null)
                {
                    leagueEntity.LeagueName = leagueElement.Element("league-name").Value; // и почвам да го пълня

                    if (context.Leagues.Any(m => m.LeagueName == leagueEntity.LeagueName)) // проверявам дали съществува обект с такова име
                    {
                        Console.WriteLine("Existing league: {0}", leagueEntity.LeagueName);
                    }
                    else
                    {
                        context.Leagues.AddOrUpdate(leagueEntity); // ако не съществъва в базата го добавям в базата
                        Console.WriteLine("Created league: {0}", leagueEntity.LeagueName);
                    }
                }
                
                if (leagueElement.Element("teams") != null) // проверям дали съществува такъв елемент, защото по условия е optional
                {
                    foreach (var teamElement in leagueElement.Element("teams").Elements()) // вървя по вътрешните елементи
                    {
                        if (teamElement != null) // проверявам дали съществува такъв елемент, защото по условие е optional
                        {
                            var teamEntity = new Team(); // създавам си нов обект

                            teamEntity.TeamName = teamElement.Attribute("name").Value; // и почвам да го пълня

                            if (teamElement.Attribute("country") != null) // проверявам дали съществува такъв атрибут, защото по условие е optional
                            {
                                var countryname = teamElement.Attribute("country").Value;
                                teamEntity.CountryCode = context.Countries
                                    .Where(c => c.CountryName == countryname)
                                    .Select(c => c.CountryCode)
                                    .FirstOrDefault(); ;
                            }

                            if (context.Teams.Any(t => t.TeamName == teamEntity.TeamName) &&
                                context.Teams.Any(t => t.CountryCode == teamEntity.CountryCode))
                                // проверявам дали съществува такъв модел лещи в базата
                            {
                                Console.WriteLine("Existing team: {0} ({1})", teamEntity.TeamName,
                                    teamElement.Attribute("country").Value);
                            }
                            else
                            {
                                context.Teams.AddOrUpdate(teamEntity);
                                    // и ако не съществува го добавям целията обект в базата
                                //context.Countries.AddOrUpdate(countryEntity);
                                Console.WriteLine("Created team: {0} ({1})", teamEntity.TeamName,
                                    teamElement.Attribute("country") != null
                                        ? teamElement.Attribute("country").Value
                                        : "no country");

                            }
                            if (leagueEntity.LeagueName != null && teamEntity.TeamName != null && !context.Leagues.Any(l => l.LeagueName == leagueEntity.LeagueName))
                            {
                                Console.WriteLine("Added team to league: {0} to league {1}", teamEntity.TeamName, leagueEntity.LeagueName);
                            }
                            if (context.Teams.Any(t => t.TeamName == teamEntity.TeamName) && context.Leagues.Any(l=>l.LeagueName == leagueEntity.LeagueName))
                            {
                                Console.WriteLine("Existing team in league: {0} belongs to {1}", teamEntity.TeamName, leagueEntity.LeagueName);
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
