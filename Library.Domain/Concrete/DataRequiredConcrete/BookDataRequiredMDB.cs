using Library.Domain.Abstracts;
using Library.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Library.Domain.Concrete
{
    public class BookDataRequiredMDB : IDataRequired<Book>
    {
        public bool IsDataNoEmpty(Book book)
        {
            bool isDataNoEmpty = false;

            if (book.Year != null && !String.IsNullOrEmpty(book.Name) && !String.IsNullOrEmpty(book.Description) && !String.IsNullOrEmpty(book.AuthorId))
            {
                isDataNoEmpty = true;
            }

            return isDataNoEmpty;
        }
    }
}
