using System.Linq;
using System.Xml.Linq;
using _1.Problem;

namespace _3.Problem
{
    class Program
    {
        static void Main()
        {
            var context = new DiabloEntities();
            var finishedGamesQuery =
                context.Games
                    .Where(g => g.IsFinished)
                    .OrderBy(g => g.Name)
                    .ThenBy(g => g.Duration)
                    .Select(g => new
                    {
                       name = g.Name,
                       duration = g.Duration,
                       users = g.UsersGames
                       .Select(u => new
                       {
                           username = u.User.Username,
                           ipAddress = u.User.IpAddress
                       })
                    })
                    .ToList();

            var xmlRoot = new XElement("games");

            foreach (var game in finishedGamesQuery)
            {
                var gameXml =
                    new XElement("game", new XAttribute("name", game.name),
                        game.duration.HasValue ? new XAttribute("duration", game.duration) : null);

                var userXml = new XElement("users");
                foreach (var user in game.users)
                {
                    userXml.Add(new XElement("user", new XAttribute("username", user.username), new XAttribute("ip-address", user.ipAddress)));
                }

                gameXml.Add(userXml);
                xmlRoot.Add(gameXml);
            }

            xmlRoot.Save("finished-games.xml");
        }
    }
}
