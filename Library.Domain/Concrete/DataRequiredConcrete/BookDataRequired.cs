using Library.Domain.Abstracts;
using Library.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Library.Domain.Concrete
{
    public class BookDataRequired : IDataRequired<Book>
    {
        public bool IsDataRequered(Book book)
        {
            bool IsDataNoEmpty = false;
            if (book.Year != null && !String.IsNullOrEmpty(book.Name) && !String.IsNullOrEmpty(book.Description) && !String.IsNullOrEmpty(book.AuthorId))
            {
                IsDataNoEmpty = true;
            }
            return IsDataNoEmpty;
        }
    }
}
