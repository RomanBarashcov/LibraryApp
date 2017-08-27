using Library.Domain.Abstracts;
using Library.Domain.Entities;
using Library.Domain.Helper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
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
            return await Task.Run(() =>
            {
                List<BookMsSql> BookList = db.Books.ToList();

                if (BookList != null)
                {
                    MssqlBookDataHelper Books = new MssqlBookDataHelper(BookList);
                    result = Books.GetIEnumerubleDbResult();
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
                    int authorId = Convert.ToInt32(book.AuthorId);
                    BookMsSql newBook = new BookMsSql { Name = book.Name, Description = book.Description, Year = book.Year, AuthorId = authorId };
                    db.Books.Add(newBook);
                    db.SaveChanges();
                    return new HttpResponseMessage(HttpStatusCode.Created);
                }
                else
                {
                    return new HttpResponseMessage(HttpStatusCode.BadRequest);
                }
            });
        }

        public async Task<HttpResponseMessage> UpdateBook(string id, Book book)
        {
            return await Task.Run(() =>
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
                    return new HttpResponseMessage(HttpStatusCode.Created);
                }
                else
                {
                    return new HttpResponseMessage(HttpStatusCode.BadRequest);
                }
            });
        }

        public async Task<HttpResponseMessage> DeleteBook(string id)
        {
            return await Task.Run(() =>
            {
                BookMsSql book = null;
                int delBookId = Convert.ToInt32(id);
                book = db.Books.Find(delBookId);

                if (book != null)
                {
                    db.Books.Remove(book);
                    db.SaveChanges();
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
