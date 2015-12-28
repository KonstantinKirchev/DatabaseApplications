using System.IO;
using System.Linq;
using System.Web.Script.Serialization;
using _1.Problem;

namespace _2.Problem
{
    class Program
    {
        static void Main()
        {
            var context = new DiabloEntities();
            var characters = context.Characters
                .OrderBy(c => c.Name)
                .Select(c => new
                {
                    name = c.Name,
                    playedBy = c.UsersGames.Select(u => u.User.Username)
                })
                .ToList();

            var json = new JavaScriptSerializer().Serialize(characters);

            File.WriteAllText(@"characters.json", json);
        }
    }
}
