using Library.Domain.Abstracts;
using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Concrete
{
    public class AuthorRepository : IAuthorRepository
    {
        private LibraryContext db = new LibraryContext();
        public IQueryable<Author> GetAllAuthors()
        {
            return db.Authors;
        }

        public Author GetAuthorById(int authorId)
        {
            Author author = db.Authors.Find(authorId);
            if (author != null)
            {
                return author;
            }
            return null;
        }
        public void CreateAuthor(Author author)
        {
            if (author != null)
            {
                db.Authors.Add(author);
                db.SaveChanges();
            }
        }

        public void UpdateAuthor(int authorId, Author author)
        {
            if (authorId == author.Id)
            {
                db.Entry(author).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void DeleteAuthor(int authorId)
        {
            Author author = db.Authors.Find(authorId);
            if (author != null)
            {
                db.Authors.Remove(author);
                db.SaveChanges();
            }
        }
    }
}
