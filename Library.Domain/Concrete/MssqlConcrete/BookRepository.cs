using Library.Domain.Abstracts;
using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Domain.Concrete
{
    public class BookRepository : IBookRepository
    {
        private IEnumerable<Book> result = null;
        private IConvertDataHelper<BookMsSql, Book> MsSqlDataConvert;
        private IDataRequired<Book> dataReqiered;
        private LibraryContext db = new LibraryContext();

        public BookRepository(IConvertDataHelper<BookMsSql, Book> msSqlDataConvert, IDataRequired<Book> dReqiered)
        {
            this.MsSqlDataConvert = msSqlDataConvert;
            this.dataReqiered = dReqiered;
        }

        public async Task<IEnumerable<Book>> GetAllBooks()
        {
             List<BookMsSql> BookList = await db.Books.ToListAsync();

             if (BookList != null)
             {
                 MsSqlDataConvert.InitData(BookList);
                 result = MsSqlDataConvert.GetIEnumerubleDbResult();
             }
             return result; 
        }

        public async Task<int> CreateBook(Book book)
        {
            int DbResult = 0;
            int authorId = 0;
            if (dataReqiered.IsDataNoEmpty(book))
            {
                try
                {
                    authorId = Convert.ToInt32(book.AuthorId);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return DbResult;
                }

                BookMsSql newBook = new BookMsSql { Name = book.Name, Description = book.Description, Year = book.Year, AuthorId = authorId };
                db.Books.Add(newBook);

                try
                {
                    DbResult = await db.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return DbResult;
                }
            }
            return DbResult;
        }

        public async Task<int> UpdateBook(string id, Book book)
        {
            int DbResult = 0;
            int oldDataBookId, newDataBookId = 0;

            if (!String.IsNullOrEmpty(id) && dataReqiered.IsDataNoEmpty(book))
            {
                oldDataBookId = Convert.ToInt32(id);
                newDataBookId = Convert.ToInt32(book.Id);
                BookMsSql updatingBook = null;
                updatingBook = await db.Books.FindAsync(oldDataBookId);

                if (oldDataBookId == newDataBookId)
                {
                    updatingBook.Year = book.Year;
                    updatingBook.Name = book.Name;
                    updatingBook.Description = book.Description;
                    db.Entry(updatingBook).State = EntityState.Modified;
                    try
                    {
                        DbResult = await db.SaveChangesAsync();
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

        public async Task<int> DeleteBook(string id)
        {
            int DbResult = 0;
            BookMsSql book = null;
            if (!String.IsNullOrEmpty(id))
            {
                int delBookId = Convert.ToInt32(id);
                book = db.Books.Find(delBookId);

                if (book != null)
                {
                    db.Books.Remove(book);
                    DbResult = await db.SaveChangesAsync();
                }
            }
            return DbResult;
        }

        public async Task<IEnumerable<Book>> GetBookByAuthorId(string authorId)
        {
            if (!String.IsNullOrEmpty(authorId))
            {
                int author_Id = Convert.ToInt32(authorId);
                List<BookMsSql> BookList = await db.Books.Where(x => x.AuthorId == author_Id).ToListAsync();

                if (BookList != null)
                {
                    MsSqlDataConvert.InitData(BookList);
                    result = MsSqlDataConvert.GetIEnumerubleDbResult();
                }
            }
            return result;
        }
    }
}
