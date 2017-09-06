using Library.Domain.Abstracts;
using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Concrete
{
    public class BookDataRequired : IDataRequired<Book>
    {
        public async Task<bool> IsDataRequered(Book book)
        {
            bool IsDataNoEmpty = false;
            if (book.Year != null && !String.IsNullOrEmpty(book.Name) && !String.IsNullOrEmpty(book.Description) && !String.IsNullOrEmpty(book.AuthorId))
            {
                IsDataNoEmpty = true;
            }
            return await Task.Run(() => { return IsDataNoEmpty; });
        }
    }
}
