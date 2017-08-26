using Library.Domain.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Concrete
{
    public class LibraryMongoDbContext : DbContext
    {
        MongoClient client;
        IMongoDatabase database;

        public LibraryMongoDbContext() : base("MongoDbConnection")
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MongoDbConnection"].ConnectionString;
            var con = new MongoUrlBuilder(connectionString);
            client = new MongoClient(connectionString);
            database = client.GetDatabase("Library");
        }

        public IMongoCollection<AuthorMongoDb> Authors
        {
            get{ return database.GetCollection<AuthorMongoDb>("Author"); }
        }

        public IMongoCollection<BookMongoDb> Books
        {
            get { return database.GetCollection<BookMongoDb>("Book"); }
        }
    }
}
