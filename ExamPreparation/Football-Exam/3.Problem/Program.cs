using System;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;
using _1.Problem;

namespace _3.Problem
{
    class Program
    {
        static void Main()
        {
            var context = new FootballExamEntities();
            
            var matches = context.InternationalMatches
                .OrderBy(em=>em.MatchDate)
                .ThenBy(em=>em.CountryHome.CountryName)
                .ThenBy(em=>em.CountryAway.CountryName)
                .Select(em => new
                {
                    homeCode = em.HomeCountryCode,
                    awayCode = em.AwayCountryCode,
                    homeGoals = em.HomeGoals,
                    awayGoals = em.AwayGoals,
                    leagueName = em.League.LeagueName,
                    date = em.MatchDate,
                    homeCountry = em.CountryHome.CountryName,
                    awayCountry = em.CountryAway.CountryName
                })
                .ToList();

            var xmlRoot = new XElement("matches");

            foreach (var match in matches)
            {
                var matchXml =
                    new XElement("match",
                        new XElement("home-country",
                            new XAttribute("code", match.homeCode), match.homeCountry),
                        new XElement("away-country", 
                            new XAttribute("code", match.awayCode), match.awayCountry));

                if (match.leagueName != null)
                {
                    matchXml.Add(new XElement("league",match.leagueName));
                }
                if (match.homeGoals != null && match.awayGoals != null)
                {
                    matchXml.Add(new XElement("score",match.homeGoals + "-" + match.awayGoals));
                }
                if (match.date != null)
                {
                    DateTime dateTime; 
                    DateTime.TryParse(match.date.ToString(), out dateTime);

                    if (dateTime.TimeOfDay.TotalSeconds == 0)
                    {
                        matchXml.Add(new XAttribute("date", dateTime.ToString("dd-MMM-yyyy", new CultureInfo("en-US"))));
                    }
                    else
                    {
                        matchXml.Add(new XAttribute("date-time", dateTime.ToString("dd-MMM-yyyy hh:mm", new CultureInfo("en-US"))));
                    }
                }
                xmlRoot.Add(matchXml);
            }
            xmlRoot.Save("international-matches.xml");
        }
    }
}
