using Library.Domain.Abstracts;
using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Concrete
{
    public class BookRepository : IBookRepository
    {
        private LibraryContext db = new LibraryContext();
        public IQueryable<Book> GetAllBooks()
        {
            return db.Books;
        }

        public Book GetBookById(int bookId)
        {
            Book book = db.Books.Find(bookId);
            if (book != null)
            {
                return book;
            }
            return null;
        }

        public void CreateBook(Book book)
        {
            if (book != null)
            {
                db.Books.Add(book);
                db.SaveChanges();
            }
        }

        public void UpdateBook(int bookId, Book book)
        {
            if (bookId == book.Id)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void DeleteBook(int bookId)
        {
            Book book = db.Books.Find(bookId);
            if (book != null)
            {
                db.Books.Remove(book);
                db.SaveChanges();
            }
        }
    }
}
