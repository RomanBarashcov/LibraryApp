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
        IQueryable<Book> GetAllBooks();
        Book GetBookById(int bookId);
        void CreateBook(Book book);
        void UpdateBook(int bookId, Book book);
        void DeleteBook(int bookId);
        IQueryable<Book> GetBookByAuthorId(int authorId);
    }
}
