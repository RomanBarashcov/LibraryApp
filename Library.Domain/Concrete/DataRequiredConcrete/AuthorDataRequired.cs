using Library.Domain.Abstracts;
using Library.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Library.Domain.Helper.DataRequired.MongoDbDataRequired
{
    public class AuthorDataRequired : IDataRequired<Author>
    {
        public bool IsDataNoEmpty(Author author)
        {
            bool isDataNoEmpty = false;
            if(!String.IsNullOrEmpty(author.Name) && !String.IsNullOrEmpty(author.Surname))
            {
                isDataNoEmpty = true;
            }
            return isDataNoEmpty;
        }
    }
}
