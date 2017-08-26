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

namespace Library.Domain.Concrete
{
    public class BookMongoDbRepository : IBookRepository
    {
        private IEnumerable<Book> result = null;
        LibraryMongoDbContext db = new LibraryMongoDbContext();

        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            var builder = Builders<BookMongoDb>.Filter;
            var filters = new List<FilterDefinition<BookMongoDb>>();
            List<BookMongoDb> CollectionResult = db.Books.Find(builder.Empty).ToList();
            MongoDbBookDataHelper DbHelper = new MongoDbBookDataHelper(CollectionResult);
            return await Task.Run(() => { return DbHelper.GetIEnumerubleDbResult(); });
        }

        public async  void CreateBook(Book book)
        {
            if(book != null)
            {
                BookMongoDb newBook = new BookMongoDb { Id = book.Id, Year = book.Year, Name = book.Name, Description = book.Description, AuthorId = book.AuthorId };
                await db.Books.InsertOneAsync(newBook);
            }
        }

        public async void UpdateBook(string bookId, Book book)
        {
            List<BookMongoDb> oldBookData = await db.Books.Find(new BsonDocument("_id", new ObjectId(bookId))).ToListAsync();
            if (oldBookData != null && book != null)
            {
                BookMongoDb newBookData = new BookMongoDb { Id = book.Id, Year = book.Year, Name = book.Name, Description = book.Description, AuthorId = book.AuthorId };
                await db.Books.ReplaceOneAsync(new BsonDocument("_id", new ObjectId(bookId)), newBookData);
            }
        }

        public async void DeleteBook(string bookId)
        {
            List<BookMongoDb> deletingBook = await db.Books.Find(new BsonDocument("_id", new ObjectId(bookId))).ToListAsync();
            if (deletingBook != null)
            {
                await db.Books.DeleteOneAsync(new BsonDocument("_id", new ObjectId(bookId)));
            }
        }

        public async Task<IEnumerable<Book>> GetBookByAuthorId(string authorId)
        {
            List<BookMongoDb> BooksByAuthor = await db.Books.Find(new BsonDocument("AuthorId", authorId)).ToListAsync();
            MongoDbBookDataHelper DbHelper = new MongoDbBookDataHelper(BooksByAuthor);
            return DbHelper.GetIEnumerubleDbResult();
        }
    }
}
