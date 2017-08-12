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
        IQueryable<Author> GetAllAuthors();
        Author GetAuthorById(int authorId);
        void CreateAuthor(Author author);
        void UpdateAuthor(int authorId, Author author);
        void DeleteAuthor(int authorId);
    }
}
