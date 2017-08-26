using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Abstracts
{
    public interface IAuthorRepository
    {
        Task<IEnumerable<Author>> GetAllAuthors();
        void CreateAuthor(Author author);
        void UpdateAuthor(string authorId, Author author);
        void DeleteAuthor(string authorId);
    }
}
