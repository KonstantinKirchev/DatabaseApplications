namespace NewsDB.Data
{
    using NewsDB.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class NewsDBEntities : DbContext
    {
        public NewsDBEntities()
            : base("name=NewsDBEntities")
        {
        }

        public IDbSet<News> News { get; set; }
    }

}