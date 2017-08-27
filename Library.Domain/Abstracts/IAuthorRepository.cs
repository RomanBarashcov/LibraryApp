using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Abstracts
{
    public interface IAuthorRepository
    {
        Task<IEnumerable<Author>> GetAllAuthors();
        Task<HttpResponseMessage> CreateAuthor(Author author);
        Task<HttpResponseMessage> UpdateAuthor(string authorId, Author author);
        Task<HttpResponseMessage> DeleteAuthor(string authorId);
    }
}
