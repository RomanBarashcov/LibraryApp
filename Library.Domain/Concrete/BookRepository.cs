using Library.Domain.Abstracts;
using Library.Domain.Entities;
using Library.Domain.Helper;
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
        private IEnumerable<Book> result = null;
        private LibraryContext db = new LibraryContext();

        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            List<BookMsSql> BookList = db.Books.ToList();

            if(BookList != null)
            {
                MssqlBookDataHelper Books = new MssqlBookDataHelper(BookList);
                result = Books.GetIEnumerubleDbResult();
            }

            return await Task.Run(() => { return result; });
        }

        public void CreateBook(Book book)
        {
            if (book != null)
            {
                int authorId = Convert.ToInt32(book.AuthorId);
                BookMsSql newBook = new BookMsSql { Name = book.Name , Description = book.Description, Year = book.Year, AuthorId = authorId };
                db.Books.Add(newBook); 
                db.SaveChanges();
            }
        }

        public void UpdateBook(string id, Book book)
        {
            int upBookId = Convert.ToInt32(id);
            int Book_book_id = Convert.ToInt32(book.Id);
            BookMsSql updatingBook = null;
            updatingBook = db.Books.Find(upBookId);

            if (upBookId == Book_book_id)
            {
                updatingBook.Year = book.Year;
                updatingBook.Name = book.Name;
                updatingBook.Description = book.Description;
                db.Entry(updatingBook).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void DeleteBook(string id)
        {
            BookMsSql book = null;
            int delBookId = Convert.ToInt32(id);
            book = db.Books.Find(delBookId);

            if (book != null)
            {
                db.Books.Remove(book);
                db.SaveChanges();
            }
        }

        public async Task<IEnumerable<Book>> GetBookByAuthorId(string authorId)
        {
            int author_Id = Convert.ToInt32(authorId);
            List<BookMsSql> BookList = db.Books.Where(x => x.AuthorId == author_Id).ToList();

            if (BookList != null)
            {
                MssqlBookDataHelper Books = new MssqlBookDataHelper(BookList);
                result = Books.GetIEnumerubleDbResult();
            }

            return await Task.Run(() => { return result; }); 
        }
    }
}
