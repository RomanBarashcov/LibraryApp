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
        Task<int> CreateAuthor(Author author);
        Task<int> UpdateAuthor(string authorId, Author author);
        Task<int> DeleteAuthor(string authorId);
    }
}
