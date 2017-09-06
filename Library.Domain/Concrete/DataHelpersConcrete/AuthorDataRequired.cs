using Library.Domain.Abstracts;
using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Helper.DataRequired.MongoDbDataRequired
{
    public class AuthorDataRequired : IDataRequired<Author>
    {
        public async Task<bool> IsDataRequered(Author author)
        {
            bool IsDataNoEmpty = false;
            if(!String.IsNullOrEmpty(author.Name) && !String.IsNullOrEmpty(author.Surname))
            {
                IsDataNoEmpty = true;
            }
            return await Task.Run(() => { return IsDataNoEmpty; });
        }
    }
}
