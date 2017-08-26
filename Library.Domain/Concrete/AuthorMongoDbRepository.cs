using Library.Domain.Abstracts;
using Library.Domain.Entities;
using Library.Domain.Helper;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Concrete
{
    public class AuthorMongoDbRepository : IAuthorRepository
    {
        LibraryMongoDbContext db = new LibraryMongoDbContext();

        public async Task<IEnumerable<Author>> GetAllAuthors()
        {
            var builder = Builders<AuthorMongoDb>.Filter;
            var filters = new List<FilterDefinition<AuthorMongoDb>>();
            List<AuthorMongoDb> CollectionResult = db.Authors.Find(builder.Empty).ToList();
            MongoDbAuthorDataHelper DbHelper = new MongoDbAuthorDataHelper(CollectionResult);
            return await Task.Run(() => { return DbHelper.GetIEnumerubleDbResult(); }); 
        }
 
        public async void CreateAuthor(Author author)
        {
            if (author != null)
            {
                AuthorMongoDb newAuthor = new AuthorMongoDb{ Id = author.Id, Name = author.Name, Surname = author.Surname };
                await db.Authors.InsertOneAsync(newAuthor);
            }
        }

        public async void UpdateAuthor(string authorId, Author author)
        {
            AuthorMongoDb oldAuthorData = await db.Authors.Find(new BsonDocument("_id", new ObjectId(authorId))).FirstOrDefaultAsync();
            if (oldAuthorData != null && author != null)
            {
                AuthorMongoDb newAuthorData = new AuthorMongoDb { Id = author.Id, Name = author.Name, Surname = author.Surname };
                await db.Authors.ReplaceOneAsync(new BsonDocument("_id", new ObjectId(authorId)), newAuthorData);
            }
        }

        public async void DeleteAuthor(string authorId)
        {
            List<AuthorMongoDb> CollectionResult = await db.Authors.Find(new BsonDocument("_id", new ObjectId(authorId))).ToListAsync();
            MongoDbAuthorDataHelper DbHelper = new MongoDbAuthorDataHelper(CollectionResult);
            IEnumerable<Author> deletingAuthor =  DbHelper.GetIEnumerubleDbResult();

            if (deletingAuthor != null)
            {
                await db.Authors.DeleteOneAsync(new BsonDocument("_id", new ObjectId(authorId)));
            }
        }
    }
}
