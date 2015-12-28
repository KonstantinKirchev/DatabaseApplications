using System.Globalization;
using System.IO;
using BookShopSystem.Models;

namespace BookShopSystem.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public class Configuration : DbMigrationsConfiguration<BookShopContext>
    {
        public Configuration()
        {
            //this.AutomaticMigrationDataLossAllowed = true;
            this.AutomaticMigrationsEnabled = true;
            this.ContextKey = "BookShopSystem.Data.BookShopContext";
        }

        protected override void Seed(BookShopContext context)
        {
            //using (var reader = new StreamReader("authors.txt"))
            //{
            //    var line = reader.ReadLine();
            //    line = reader.ReadLine();
            //    while (line != null)
            //    {
            //        var data = line.Split(' ');
            //        var firstname = data[0];
            //        var lastname = data[1];
                    

            //        context.Authors.Add(new Author()
            //        {
            //            FirstName = firstname,
            //            LastName = lastname
            //        });
            //        context.SaveChanges();
            //        line = reader.ReadLine();
            //    }
            //}

            using (var reader = new StreamReader("categories.txt"))
            {
                var line = reader.ReadLine();
                //line = reader.ReadLine();
               // while (line != null)
                //{
                    var name = line;
                    context.Categories.Add(new Category()
                    {
                        Name = "Crime"
                    });
                    context.SaveChanges();
                    //line = reader.ReadLine();
                //}
            }

            //using (var reader = new StreamReader("books.txt"))
            //{
            //    var line = reader.ReadLine();
            //    line = reader.ReadLine();
            //    while (line != null)
            //    {
            //        var random = new Random();
            //        var data = line.Split(new[] { ' ' }, 6);
            //        var authorIndex = random.Next(0, context.Authors.Count()-1);
            //        //var author = context.Authors[authorIndex];
            //        var edition = (Edition)int.Parse(data[0]);
            //        var releaseDate = DateTime.ParseExact(data[1], "d/M/yyyy", CultureInfo.InvariantCulture);
            //        var copies = int.Parse(data[2]);
            //        var price = decimal.Parse(data[3]);
            //        var ageRestriction = (AgeRestriction)int.Parse(data[4]);
            //        var title = data[5];

            //        context.Books.Add(new Book()
            //        {
            //            AuthorId = authorIndex,
            //            Edition = edition,
            //            ReleaseDate = releaseDate,
            //            Copies = copies,
            //            Price = price,
            //            AgeRestriction = ageRestriction,
            //            Title = title
            //        });
            //        context.SaveChanges();
            //        line = reader.ReadLine();
            //    }
            //}
        }
    }
}
