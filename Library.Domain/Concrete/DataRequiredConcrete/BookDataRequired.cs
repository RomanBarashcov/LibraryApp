using Library.Domain.Abstracts;
using Library.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Library.Domain.Concrete
{
    public class BookDataRequired : IDataRequired<Book>
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

        private bool IsDataConvertingCorrect(string bookAuthorId)
        {
            bool IsConveted = false;
            int bAuthorId = 0;

            try
            {
                bAuthorId = Convert.ToInt32(bookAuthorId);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return IsConveted;
            }

            return IsConveted;
        }
    }
}
