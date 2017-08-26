using Library.Domain.Abstracts;
using Library.Domain.Entities;
using Library.Domain.Helper;
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
        private IEnumerable<Author> result = null;
        private LibraryContext db = new LibraryContext();

        public async Task<IEnumerable<Author>> GetAllAuthors()
        {
            List<AuthorMsSql> AuthorList = db.Authors.ToList();

            if (AuthorList != null)
            {
                MssqlAuthorDataHelper Authors = new MssqlAuthorDataHelper(AuthorList);
                result = Authors.GetIEnumerubleDbResult();
            }

            return await Task.Run(() => { return this.result; });
        }

        public void CreateAuthor(Author author)
        {
            if (author != null)
            {
                AuthorMsSql newAuthor = new AuthorMsSql{ Name = author.Name, Surname = author.Surname  };
                db.Authors.Add(newAuthor); 
                db.SaveChanges();
            }
        }

        public void UpdateAuthor(string authorId, Author author)
        {
            int upAuthorId = Convert.ToInt32(authorId);
            int Author_author_id = Convert.ToInt32(author.Id);
            AuthorMsSql updatingAuthor = null;
            updatingAuthor = db.Authors.Find(upAuthorId);
 
            if (upAuthorId == Author_author_id)
            {
                updatingAuthor.Name = author.Name;
                updatingAuthor.Surname = author.Surname;
                db.Entry(updatingAuthor).State = EntityState.Modified;
                db.SaveChanges(); 
             }
        }

        public void DeleteAuthor(string authorId)
        {
            int delAuthorId = Convert.ToInt32(authorId);
            AuthorMsSql author = db.Authors.Find(delAuthorId);

            if (author != null)
            {
                 db.Authors.Remove(author);
                 db.SaveChanges();
            }
        }
    }
}
