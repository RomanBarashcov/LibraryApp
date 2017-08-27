using Library.Domain.Abstracts;
using Library.Domain.Entities;
using Library.Domain.Helper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
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
            return await Task.Run(() =>
            {
                List<AuthorMsSql> AuthorList = db.Authors.ToList();

                if (AuthorList != null)
                {
                    MssqlAuthorDataHelper Authors = new MssqlAuthorDataHelper(AuthorList);
                    result = Authors.GetIEnumerubleDbResult();
                }

                return result;
            });
        }

        public async Task<HttpResponseMessage> CreateAuthor(Author author)
        {
           return await Task.Run(() =>
            {
                if (author != null)
                {
                    AuthorMsSql newAuthor = new AuthorMsSql { Name = author.Name, Surname = author.Surname };
                    db.Authors.Add(newAuthor);
                    db.SaveChanges();
                    return new HttpResponseMessage(HttpStatusCode.Created);
                }
                else
                {
                    return new HttpResponseMessage(HttpStatusCode.BadRequest);
                }
            });
        }

        public async Task<HttpResponseMessage> UpdateAuthor(string authorId, Author author)
        {
            return await Task.Run(() =>
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
                    return new HttpResponseMessage(HttpStatusCode.Created);
                }
                else
                {
                    return new HttpResponseMessage(HttpStatusCode.BadRequest);
                }
            });
        }

        public async Task<HttpResponseMessage> DeleteAuthor(string authorId)
        {
            return await Task.Run(() =>
            {
                int delAuthorId = Convert.ToInt32(authorId);
                AuthorMsSql author = db.Authors.Find(delAuthorId);

                if (author != null)
                {
                    db.Authors.Remove(author);
                    db.SaveChanges();
                    return new HttpResponseMessage(HttpStatusCode.Created);
                }
                else
                {
                    return new HttpResponseMessage(HttpStatusCode.BadRequest);
                }
            }); 
        }
    }
}
