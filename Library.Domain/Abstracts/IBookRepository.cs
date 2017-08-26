using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Abstracts
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllBooks();
        void CreateBook(Book book);
        void UpdateBook(string bookId, Book book);
        void DeleteBook(string bookId);
        Task<IEnumerable<Book>> GetBookByAuthorId(string authorId);
    }
}
