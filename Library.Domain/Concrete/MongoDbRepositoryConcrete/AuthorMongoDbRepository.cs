using Library.Domain.Abstracts;
using Library.Domain.Entities;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Library.Domain.Concrete
{
    public class AuthorMongoDbRepository : IAuthorRepository
    {
        private IEnumerable<Author> result = null;
        private IConvertDataHelper<AuthorMongoDb, Author> mongoDbDataConvert;
        private IDataRequired<Author> dataReqiered;
        LibraryMongoDbContext db;

        public AuthorMongoDbRepository(LibraryMongoDbContext context, IConvertDataHelper<AuthorMongoDb, Author> mDbDataConvert, IDataRequired<Author> dReqiered)
        {
            this.db = context;
            this.mongoDbDataConvert = mDbDataConvert;
            this.dataReqiered = dReqiered;
        }

        public async Task<IEnumerable<Author>> GetAllAuthors()
        {
             var builder = Builders<AuthorMongoDb>.Filter;
             var filters = new List<FilterDefinition<AuthorMongoDb>>();
             List<AuthorMongoDb> CollectionResult = await db.Authors.Find(builder.Empty).ToListAsync();

             if(CollectionResult != null)
             {
                 mongoDbDataConvert.InitData(CollectionResult);
                 result = mongoDbDataConvert.GetIEnumerubleDbResult();
             }
             return result;
        }
 
        public async Task<int> CreateAuthor(Author author)
        {
            int DbResult = 0;
            if (dataReqiered.IsDataNoEmpty(author))
            {
                AuthorMongoDb newAuthor = new AuthorMongoDb { Id = author.Id, Name = author.Name, Surname = author.Surname };
                try
                {
                    await db.Authors.InsertOneAsync(newAuthor);
                    DbResult = 1;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return DbResult;
                }
            }
            return DbResult;
        }

        public async Task<int> UpdateAuthor(string authorId, Author author)
        {
            int DbResult = 0;
            if (!String.IsNullOrEmpty(authorId) && dataReqiered.IsDataNoEmpty(author))
            {
                AuthorMongoDb oldAuthorData = await db.Authors.Find(new BsonDocument("_id", new ObjectId(authorId))).FirstOrDefaultAsync();
                if (oldAuthorData != null)
                {
                    AuthorMongoDb newAuthorData = new AuthorMongoDb { Id = author.Id, Name = author.Name, Surname = author.Surname };
                    try
                    {
                        await db.Authors.ReplaceOneAsync(new BsonDocument("_id", new ObjectId(authorId)), newAuthorData);
                        DbResult = 1;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        return DbResult;
                    }
                }
            }
            return DbResult;
        }

        public async Task<int> DeleteAuthor(string authorId)
        {
            int DbResult = 0;
            if (!String.IsNullOrEmpty(authorId))
            {
                List<AuthorMongoDb> CollectionResult = await db.Authors.Find(new BsonDocument("_id", new ObjectId(authorId))).ToListAsync();
                mongoDbDataConvert.InitData(CollectionResult);
                IEnumerable<Author> deletingAuthor = mongoDbDataConvert.GetIEnumerubleDbResult();

                if (deletingAuthor != null)
                {
                    await db.Authors.DeleteOneAsync(new BsonDocument("_id", new ObjectId(authorId)));
                    DbResult = 1;
                }
            }
            return DbResult;
        }
    }
}
