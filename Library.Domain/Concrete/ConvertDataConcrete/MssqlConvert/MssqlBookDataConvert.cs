using Library.Domain.Abstracts;
using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Helper
{
    public class MssqlBookDataConvert : IConvertDataHelper<BookMsSql, Book>
    {
        private List<BookMsSql> Books = new List<BookMsSql>();
        private BookMsSql BookMssql = new BookMsSql();
        private Book booksNode = new Book();
        private List<Book> ListBook = new List<Book>();
        private IEnumerable<Book> result = null;

        public void InitData(List<BookMsSql> books)
        {
            Books = books;
        }

        public IEnumerable<Book> GetIEnumerubleDbResult()
        {
            foreach (BookMsSql b in Books)
            {
                BookMssql = new BookMsSql { Id = b.Id, Name = b.Name, Year = b.Year, Description = b.Description, AuthorId = b.AuthorId };
                booksNode = new Book(BookMssql);
                ListBook.Add(booksNode);
                result = ListBook;
            }

            return result;
        }
    }
}
