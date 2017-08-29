using Library.Domain.Abstracts;
using Library.Domain.Entities;
using Library.Domain.Helper;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Concrete
{
    public class AuthorMongoDbRepository : IAuthorRepository
    {
         private IEnumerable<Author> result = null;
        LibraryMongoDbContext db = new LibraryMongoDbContext();

        public async Task<IEnumerable<Author>> GetAllAuthors()
        {
            return await Task.Run(() =>
            {
                var builder = Builders<AuthorMongoDb>.Filter;
                var filters = new List<FilterDefinition<AuthorMongoDb>>();
                List<AuthorMongoDb> CollectionResult = db.Authors.Find(builder.Empty).ToList();

                if(CollectionResult != null)
                {
                    MongoDbAuthorDataHelper DbHelper = new MongoDbAuthorDataHelper(CollectionResult);
                    result = DbHelper.GetIEnumerubleDbResult();
                }
                return result;
            });
        }
 
        public async Task<int> CreateAuthor(Author author)
        {
            return await Task.Run(() => 
            {
                int DbResult = 0;
                if (author != null)
                {
                    AuthorMongoDb newAuthor = new AuthorMongoDb{ Id = author.Id, Name = author.Name, Surname = author.Surname };
                    var result = db.Authors.InsertOneAsync(newAuthor);
                    DbResult = Convert.ToInt32(result.Id);
                }
                return DbResult;
            });
        }

        public async Task<int> UpdateAuthor(string authorId, Author author)
        {
            return await Task.Run(() =>
            {
                int DbResult = 0;
                AuthorMongoDb oldAuthorData = db.Authors.Find(new BsonDocument("_id", new ObjectId(authorId))).FirstOrDefault();
                if (oldAuthorData != null && author != null)
                {
                    AuthorMongoDb newAuthorData = new AuthorMongoDb { Id = author.Id, Name = author.Name, Surname = author.Surname };
                    var result = db.Authors.ReplaceOneAsync(new BsonDocument("_id", new ObjectId(authorId)), newAuthorData);
                    DbResult = Convert.ToInt32(result.Id);
                }
                return DbResult;
            });
        }

        public async Task<int> DeleteAuthor(string authorId)
        {
            return await Task.Run(() =>
            {
                int DbResult = 0;
                List<AuthorMongoDb> CollectionResult = db.Authors.Find(new BsonDocument("_id", new ObjectId(authorId))).ToList();
                MongoDbAuthorDataHelper DbHelper = new MongoDbAuthorDataHelper(CollectionResult);
                IEnumerable<Author> deletingAuthor = DbHelper.GetIEnumerubleDbResult();

                if (deletingAuthor != null)
                {
                    var result = db.Authors.DeleteOneAsync(new BsonDocument("_id", new ObjectId(authorId)));
                    DbResult = Convert.ToInt32(result.Id);
                }
                return DbResult;
            });
        }
    }
}
