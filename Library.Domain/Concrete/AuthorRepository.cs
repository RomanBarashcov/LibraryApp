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
            Author author = db.Authors.FirstOrDefault(x=> x.Id == authorId);
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
            Author updatingAuthor = db.Authors.Find(authorId);
            if (authorId == author.Id)
            {
                updatingAuthor.Name = author.Name;
                updatingAuthor.Surname = author.Surname;
                db.Entry(updatingAuthor).State = EntityState.Modified;
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
