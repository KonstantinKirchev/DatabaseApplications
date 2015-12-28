using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsDB.Data;
using NewsDB.Models;
using System.Data.Entity.Infrastructure;

namespace NewsDB.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {

            var context = new NewsDBEntities();
            var cnt = context.News.Count();

            // TASK 1

            var cont = new News()
            {
                NewsContent = "EF 7 Beta To Be Released in May 2016."
            };
            context.News.Add(cont);
            context.SaveChanges();

            //TASK 2

            var contextFirst = new NewsDBEntities();
            ConsoleData(contextFirst);
            
            var contextSecond = new NewsDBEntities();
            ConsoleData(contextSecond);

            contextFirst.SaveChanges();

            try
            {
                contextSecond.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                var nc = contextFirst.News.OrderBy(id => id.Id).First();
                Console.WriteLine("Conflict! Text from DB: {0}", nc);
            }

            ConsoleData(contextFirst);
            contextFirst.SaveChanges();
            Console.WriteLine("Changes successfully saved in the DB.");
        }

        public static void ConsoleData(NewsDBEntities context)
        {
            var nc = context.News.OrderBy(id => id.Id).First();
            Console.WriteLine("Application started.");
            Console.WriteLine("Text from DB: {0}", nc.NewsContent);
            Console.Write("Enter the corrected text: ");
            var newCont = Console.ReadLine();
            nc.NewsContent = newCont;

        }
    }
}
