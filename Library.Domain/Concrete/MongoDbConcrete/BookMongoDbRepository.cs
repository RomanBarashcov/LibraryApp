using Library.Domain.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Domain.Entities;
using MongoDB.Driver;
using MongoDB.Bson;
using Library.Domain.Helper;
using System.Net.Http;
using System.Net;

namespace Library.Domain.Concrete
{
    public class BookMongoDbRepository : IBookRepository
    {
        private IEnumerable<Book> result = null;
        private IConvertDataHelper<BookMongoDb, Book> mongoDbDataConvert;
        LibraryMongoDbContext db = new LibraryMongoDbContext();

        public BookMongoDbRepository(IConvertDataHelper<BookMongoDb, Book> mDbDataConvert)
        {
            this.mongoDbDataConvert = mDbDataConvert;
        }


        public async Task<IEnumerable<Book>> GetAllBooks()
        {
             var builder = Builders<BookMongoDb>.Filter;
             var filters = new List<FilterDefinition<BookMongoDb>>();
             List<BookMongoDb> CollectionResult = await db.Books.Find(builder.Empty).ToListAsync();

             if (CollectionResult != null)
             {
                 mongoDbDataConvert.InitData(CollectionResult);
                 result = mongoDbDataConvert.GetIEnumerubleDbResult();
             }
             return result;
            
        }

        public async Task<int> CreateBook(Book book)
        {
            int DbResult = 0;
            if (book != null)
            {
                BookMongoDb newBook = new BookMongoDb { Id = book.Id, Year = book.Year, Name = book.Name, Description = book.Description, AuthorId = book.AuthorId };
                await db.Books.InsertOneAsync(newBook);
                DbResult = 1;
            }
            return DbResult;
        }

        public async Task<int> UpdateBook(string bookId, Book book)
        {
            int DbResult = 0;
            List<BookMongoDb> oldBookData = await db.Books.Find(new BsonDocument("_id", new ObjectId(bookId))).ToListAsync();
            if (oldBookData != null && book != null)
            {
                BookMongoDb newBookData = new BookMongoDb { Id = book.Id, Year = book.Year, Name = book.Name, Description = book.Description, AuthorId = book.AuthorId };
                await db.Books.ReplaceOneAsync(new BsonDocument("_id", new ObjectId(bookId)), newBookData);
                DbResult = 1;
            }
            return DbResult;
        }

        public async Task<int> DeleteBook(string bookId)
        {
             int DbResult = 0;
             List<BookMongoDb> deletingBook = await db.Books.Find(new BsonDocument("_id", new ObjectId(bookId))).ToListAsync();
             if (deletingBook != null)
             {
                await db.Books.DeleteOneAsync(new BsonDocument("_id", new ObjectId(bookId)));
                DbResult = 1;
             }
             return DbResult;
        }

        public async Task<IEnumerable<Book>> GetBookByAuthorId(string authorId)
        {
             List<BookMongoDb> BooksByAuthor = await db.Books.Find(new BsonDocument("AuthorId", authorId)).ToListAsync();
             if(BooksByAuthor != null)
             {
                 mongoDbDataConvert.InitData(BooksByAuthor);
                 result = mongoDbDataConvert.GetIEnumerubleDbResult();
             }
             return result;
        }
    }
}
