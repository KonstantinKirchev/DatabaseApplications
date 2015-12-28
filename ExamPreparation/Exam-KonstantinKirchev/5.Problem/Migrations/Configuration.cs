using System;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Web.Script.Serialization;
using Newtonsoft.Json.Linq;

namespace _5.Problem.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<MoviesContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(MoviesContext context)
        {

            //string textCountry = File.ReadAllText("../../countries.json");

            //JArray countries = JArray.Parse(textCountry); // взимам си отделните обекти

            //foreach (JToken country in countries) // вървя по всеки от обектите и взимам цялата информация
            //{
            //    context.Countries.Add(new Country() { Name = country["name"].ToString() });
            //    //context.SaveChanges();
            //}

            //string textMovies = File.ReadAllText("../../movies.json");

            //JArray movies = JArray.Parse(textMovies);

            //foreach (JToken movie in movies)
            //{
            //    var newMovie = new Movie
            //    {
            //        Isbn = movie["isbn"].ToString(),
            //        Title = movie["title"].ToString(),
            //        AgeRestriction = (Age)int.Parse(movie["ageRestriction"].ToString())
            //    };

            //    context.Movies.AddOrUpdate(newMovie);
            //}
            //context.SaveChanges();

            string textUsers = File.ReadAllText("../../users.json");

            JArray users = JArray.Parse(textUsers);

            foreach (JToken user in users)
            {
                if (user["country"] != null)
                {
                    var countryName = user["country"].ToString();
                    var countryid =
                        context.Countries.Where(c => c.Name == countryName).Select(c => c.Id).FirstOrDefault();

                    if (countryid == 0)
                    {
                        continue;
                    }

                    var newUser = new User();

                    newUser.Username = user["username"].ToString();
                    
                    if (user["age"] != null)
                    {
                        Console.WriteLine(user["age"].ToString());
                        newUser.Age = int.Parse(user["age"].ToString());
                    }
                    else
                    {
                        newUser.Age = null;
                    }

                    newUser.Email = user["email"].ToString();
                    newUser.CountryId = countryid;
                    
                    
                    context.Users.AddOrUpdate(newUser);
                }
            }
            context.SaveChanges();

            //string textMovieRating = File.ReadAllText("../../movie-ratings.json");

            //JArray movieRatings = JArray.Parse(textMovieRating); 

            //foreach (JToken movieRating in movieRatings) 
            //{

            //    var userName = movieRating["user"].ToString();
            //    var userid =
            //        context.Users.Where(c => c.Username == userName).Select(c => c.Id).FirstOrDefault();

            //    var movieIsbn = movieRating["movie"].ToString();
            //    var movieid =
            //        context.Movies.Where(c => c.Isbn == movieIsbn).Select(c => c.Id).FirstOrDefault();

            //    var newRating = new Rating() 
            //    {
            //        UserId = userid,
            //        MovieId = movieid,
            //        Stars = int.Parse(movieRating["rating"].ToString())
            //    };

            //    context.Raitings.AddOrUpdate(newRating);

            //}
            //context.SaveChanges();

            //string textFavouriteMovie = File.ReadAllText("../../users-and-favourite-movies.json");

            //JArray favouriteMovies = JArray.Parse(textFavouriteMovie);

            //foreach (JToken favouriteMovie in favouriteMovies) 
            //{

            //    var userName = favouriteMovie["username"].ToString();
            //    var userid =
            //        context.Users.Where(c => c.Username == userName).Select(c => c.Id).FirstOrDefault();

            //    var movieIsbn = favouriteMovie["favouriteMovies"].ToString();
            //    var movieid =
            //        context.Movies.Where(c => c.Isbn == movieIsbn).Select(c => c.Id).FirstOrDefault();

            //    var newUser = new User()
            //    {
            //        Movies = new Movie[]
            //        {
            //             new Movie {Id = movieid}
                   
            //        },
            //    };

            //    var newMovie = new Movie()
            //    {
            //        Users = new User[]
            //        {
            //             new User {Id = userid}
                   
            //        },
            //    };
            //    context.Users.AddOrUpdate(newUser);
            //    context.Movies.AddOrUpdate(newMovie);
            //}
            //context.SaveChanges();
        }
    }
}
