using System;
using System.Linq;

namespace _5.Problem
{
    class Program
    {
        static void Main()
        {
            var context = new MoviesContext();
            Console.WriteLine(context.Users.Count());
        }
    }
}
