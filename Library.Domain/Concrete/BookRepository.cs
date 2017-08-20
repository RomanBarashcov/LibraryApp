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

        public Book GetBookById(int id)
        {
            Book book = db.Books.Find(id);
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

        public void UpdateBook(int id, Book book)
        {
            if (id == book.Id)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void DeleteBook(int id)
        {
            Book book = db.Books.Find(id);
            if (book != null)
            {
                db.Books.Remove(book);
                db.SaveChanges();
            }
        }

        public IQueryable<Book> GetBookByAuthorId(int authorId)
        {
            IQueryable<Book> book = db.Books.Where(x => x.AuthorId == authorId);

            if (book != null) {
                return book;
            }
            return null; 
        }
    }
}
