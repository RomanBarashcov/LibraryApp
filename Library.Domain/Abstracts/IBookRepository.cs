using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Abstracts
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllBooks();
        Task<int> CreateBook(Book book);
        Task<int> UpdateBook(string bookId, Book book);
        Task<int> DeleteBook(string bookId);
        Task<IEnumerable<Book>> GetBookByAuthorId(string authorId);
    }
}
