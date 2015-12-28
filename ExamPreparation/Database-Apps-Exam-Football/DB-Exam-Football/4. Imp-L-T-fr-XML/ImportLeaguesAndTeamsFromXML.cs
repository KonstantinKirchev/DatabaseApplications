using System;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using _1.EF_Mappings;

namespace _4.Imp_L_T_fr_XML
{
    class ImportLeaguesAndTeamsFromXML
    {
        static void Main()
        {
            var context = new FootballExamEntities();

            XmlDocument doc = new XmlDocument();
            doc.Load("../../leagues-and-teams.xml");
            
            int id = 1;
           
            foreach (XmlNode league in doc.DocumentElement.ChildNodes)
            {
                Console.WriteLine("Processing league #{0} ....", id++);
                var leagueNameNode = league.SelectSingleNode("league-name");
                
                if (leagueNameNode != null)
                {
                    string leagueName = leagueNameNode.InnerText;
                    
                    if (context.Leagues.Any(l => l.LeagueName == leagueName))
                    {
                        Console.WriteLine("Existing league: {0}",leagueName);
                    }
                    else
                    {
                        context.Leagues.Add(new League()
                        {
                            LeagueName = leagueName
                        });
                        Console.WriteLine("Created league: {0}", leagueName);
                    }
                    
                }
                XmlNode teamsNode = league.SelectSingleNode("teams");

                if (teamsNode != null)
                {
                    foreach (XmlNode team in teamsNode.ChildNodes)
                    {
                        string teamName = team.Attributes["name"].Value;
                        string countryName = null;
                        
                        if (team.Attributes["country"] != null)
                        {
                            countryName = team.Attributes["country"].Value;
                        }

                        if (context.Teams.Any(t=>t.TeamName == teamName && t.Country.CountryName == countryName))
                        {
                            Console.WriteLine("Existing team: {0} ({1})", teamName, countryName ?? "no country");
                            Console.WriteLine("Existing team in league: {0} belongs to {1}",teamName, leagueNameNode.InnerText);
                        }
                        else
                        {
                            Country country = context.Countries.FirstOrDefault(c => c.CountryName == countryName);

                            context.Teams.Add(new Team()
                            {
                                TeamName = teamName,
                                Country = country
                            });
                            Console.WriteLine("Created team: {0} ({1})", teamName, countryName ?? "no country");
                            Console.WriteLine("Added team to league: {0} to league {1}", teamName, leagueNameNode.InnerText);
                        }
                    }
                }
                context.SaveChanges();
            }    
        }
    }
}
