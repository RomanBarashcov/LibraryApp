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
        LibraryMongoDbContext db = new LibraryMongoDbContext();

        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            return await Task.Run(() =>
            {
                var builder = Builders<BookMongoDb>.Filter;
                var filters = new List<FilterDefinition<BookMongoDb>>();
                List<BookMongoDb> CollectionResult = db.Books.Find(builder.Empty).ToList();

                if (CollectionResult != null)
                {
                    MongoDbBookDataHelper DbHelper = new MongoDbBookDataHelper(CollectionResult);
                    result = DbHelper.GetIEnumerubleDbResult();
                }
                return result;
            });
            
        }

        public async Task<HttpResponseMessage> CreateBook(Book book)
        {
            return await Task.Run(() =>
            {
                if (book != null)
                {
                    BookMongoDb newBook = new BookMongoDb { Id = book.Id, Year = book.Year, Name = book.Name, Description = book.Description, AuthorId = book.AuthorId };
                    db.Books.InsertOneAsync(newBook);
                    return new HttpResponseMessage(HttpStatusCode.Created);
                }
                else
                {
                    return new HttpResponseMessage(HttpStatusCode.BadRequest);
                }
            });
        }

        public async Task<HttpResponseMessage> UpdateBook(string bookId, Book book)
        {
            return await Task.Run(() =>
            {
                List<BookMongoDb> oldBookData = db.Books.Find(new BsonDocument("_id", new ObjectId(bookId))).ToList();
                if (oldBookData != null && book != null)
                {
                    BookMongoDb newBookData = new BookMongoDb { Id = book.Id, Year = book.Year, Name = book.Name, Description = book.Description, AuthorId = book.AuthorId };
                    db.Books.ReplaceOneAsync(new BsonDocument("_id", new ObjectId(bookId)), newBookData);
                    return new HttpResponseMessage(HttpStatusCode.Created);
                }
                else
                {
                    return new HttpResponseMessage(HttpStatusCode.BadRequest);
                }
            });
        }

        public async Task<HttpResponseMessage> DeleteBook(string bookId)
        {
            return await Task.Run(() =>
            {
                List<BookMongoDb> deletingBook = db.Books.Find(new BsonDocument("_id", new ObjectId(bookId))).ToList();
                if (deletingBook != null)
                {
                    db.Books.DeleteOneAsync(new BsonDocument("_id", new ObjectId(bookId)));
                    return new HttpResponseMessage(HttpStatusCode.OK);
                }
                else
                {
                    return new HttpResponseMessage(HttpStatusCode.BadRequest);
                }
            });
        }

        public async Task<IEnumerable<Book>> GetBookByAuthorId(string authorId)
        {
            return await Task.Run(() => 
            { 
                List<BookMongoDb> BooksByAuthor = db.Books.Find(new BsonDocument("AuthorId", authorId)).ToList();
                if(BooksByAuthor != null)
                {
                    MongoDbBookDataHelper DbHelper = new MongoDbBookDataHelper(BooksByAuthor);
                    result = DbHelper.GetIEnumerubleDbResult();
                }
                return result;
            });
        }
    }
}
