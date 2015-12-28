using System;
using System.Linq;
using BookShopSystem.Data;

namespace BookShopSystem.ConsoleClient
{
    public class BookShopMain
    {
        static void Main()
        {
            var context = new BookShopContext();
            var bookCount = context.Books.Count();
            //context.Categories.Where(c=>c.Name=="Fantasy");
            Console.WriteLine(bookCount);
        }
    }
}
