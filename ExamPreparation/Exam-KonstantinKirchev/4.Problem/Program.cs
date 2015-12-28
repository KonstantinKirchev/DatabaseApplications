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
            var context = new DiabloEntities();

            var xmlDoc = XDocument.Load("../../users-and-games.xml");

            var userElements = xmlDoc.Root.Elements(); // взимам всички елементи



            foreach (var userElement in userElements) // вървя по външните елементи
            {
                var userEntity = new User(); // създавам си нов обект

                if (userElement.Attribute("first-name") != null)
                {
                    userEntity.FirstName = userElement.Attribute("first-name").Value;
                }

                if (userElement.Attribute("last-name") != null)
                {
                    userEntity.LastName = userElement.Attribute("last-name").Value;
                }

                if (userElement.Attribute("email") != null)
                {
                    userEntity.Email = userElement.Attribute("email").Value;
                }

                userEntity.Username = userElement.Attribute("username").Value;

                userEntity.IsDeleted = userElement.Attribute("is-deleted").Value != "0";

                userEntity.IpAddress = userElement.Attribute("ip-address").Value;

                userEntity.RegistrationDate = DateTime.Parse(userElement.Attribute("registration-date").Value);

                

                if (userElement.Element("games") != null) // проверям дали съществува такъв елемент, защото по условия е optional
                {
                    foreach (var gamesElement in userElement.Element("games").Elements()) // вървя по вътрешните елементи
                    {
                        if (gamesElement != null) // проверявам дали съществува такъв елемент, защото по условие е optional
                        {
                            var gameEntity = new Game(); // създавам си нов обект

                            gameEntity.Name = gamesElement.Element("game-name").Value;

                            var userGameEntity = new UsersGame();

                            userGameEntity.JoinedOn = DateTime.Parse(gamesElement.Element("joined-on").Value);
                            userGameEntity.Cash = decimal.Parse(gamesElement.Element("character").Attribute("cash").Value);
                            userGameEntity.Level = int.Parse(gamesElement.Element("character").Attribute("level").Value);

                            var characterEntity = new Character();

                            characterEntity.Name = gamesElement.Element("character").Attribute("name").Value;

                            //The game elements describe existing games where the users should be added with their respective character, level, cash and the date they joined.
                            
                            var gameid =
                                context.Games
                                       .Where(g => g.Name == gameEntity.Name)
                                       .Select(g => g.Id)
                                       .FirstOrDefault();

                            if (context.Users.Any(m => m.Username == userEntity.Username) && context.UsersGames.Any(ug => ug.GameId == gameid)) // проверявам дали съществува обект с такова име
                            {
                                Console.WriteLine("User {0} already exists", userEntity.Username);
                            }
                            else
                            {
                                context.Users.AddOrUpdate(userEntity); // ако не съществъва в базата го добавям в базата
                                Console.WriteLine("Successfully added user {0}", userEntity.Username);
                                //context.SaveChanges();
                            }

                            var userid =
                                context.Users
                                    .Where(u => u.Username == userEntity.Username)
                                    .Select(u => u.Id)
                                    .FirstOrDefault();

                            if (!context.UsersGames.Any(u => u.UserId == userid) && !context.UsersGames.Any(u=>u.GameId == gameid)) 
                            {
                                context.Games.AddOrUpdate(gameEntity); 
                                context.UsersGames.AddOrUpdate(userGameEntity);
                                context.Characters.AddOrUpdate(characterEntity);
                                Console.WriteLine("User {0} successfully added to game {1}", userEntity.Username, gameEntity.Name);
                            }
                        }
                    }
                }
            }
            //context.SaveChanges(); // на края запазвам промените в базата
        }
    }
}
