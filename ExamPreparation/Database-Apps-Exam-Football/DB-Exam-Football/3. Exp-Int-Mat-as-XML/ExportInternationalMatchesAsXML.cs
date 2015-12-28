using System;
using System.Linq;
using System.Xml.Linq;
using _1.EF_Mappings;

namespace _3.Exp_Int_Mat_as_XML
{
    class ExportInternationalMatchesAsXML
    {
        static void Main()
        {
            var context = new FootballExamEntities();
            var matchesQuery =
                context.InternationalMatches
                .OrderBy(im => im.MatchDate)
                .ThenBy(im => im.CountryHome.CountryName)
                .ThenBy(im => im.CountryAway.CountryName)
                .Select(im => new
                {
                    Date = im.MatchDate,
                    HomeCountry = im.CountryHome.CountryName,
                    AwayCountry = im.CountryAway.CountryName,
                    HomeScore = im.HomeGoals,
                    AwayScore = im.AwayGoals,              
                    CountryCodeHome = im.HomeCountryCode,
                    CountryCodeAway = im.AwayCountryCode,
                    League = im.League.LeagueName
                })
                .ToList();

            
            var xmlRoot = new XElement("matches");
            
            foreach (var match in matchesQuery)
            {
                var matchXml =
                    new XElement("match",
                        new XElement("home-country",
                            new XAttribute("code", match.CountryCodeHome), match.HomeCountry),
                        new XElement("away-country",
                            new XAttribute("code", match.CountryCodeAway), match.AwayCountry));
                

                if (match.League != null)
                {
                    matchXml.Add(new XElement("league", match.League));
                }
                if (match.HomeScore != null && match.AwayScore != null)
                {
                    matchXml.Add(new XElement("score", match.HomeScore+"-"+match.AwayScore));
                }

                if (match.Date != null)
                {
                    DateTime dateTime;
                    DateTime.TryParse(match.Date.ToString(), out dateTime);

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
