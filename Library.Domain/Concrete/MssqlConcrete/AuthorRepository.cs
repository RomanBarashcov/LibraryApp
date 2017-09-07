using Library.Domain.Abstracts;
using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Library.Domain.Concrete
{
    public class AuthorRepository : IAuthorRepository
    {
        private IEnumerable<Author> result = null;
        private IConvertDataHelper<AuthorMsSql, Author> MsSqlDataConvert;
        private IDataRequired<Author> dataReqiered;
        private LibraryContext db = new LibraryContext();

        public AuthorRepository(IConvertDataHelper<AuthorMsSql, Author> msSqlDataConvert, IDataRequired<Author> dReqiered)
        {
            this.MsSqlDataConvert = msSqlDataConvert;
            this.dataReqiered = dReqiered;
        }

        public async Task<IEnumerable<Author>> GetAllAuthors()
        {
             List<AuthorMsSql> AuthorList = await db.Authors.ToListAsync();

             if (AuthorList != null)
             {
                 MsSqlDataConvert.InitData(AuthorList);
                 result = MsSqlDataConvert.GetIEnumerubleDbResult();
             }
             return result;
        }

        public async Task<int> CreateAuthor(Author author)
        {
             int DbResult = 0;
             if (dataReqiered.IsDataRequered(author))
             {
                  AuthorMsSql newAuthor = new AuthorMsSql { Name = author.Name, Surname = author.Surname };
                  db.Authors.Add(newAuthor);
                  DbResult =  await db.SaveChangesAsync();
             }
             return DbResult;
        }

        public async Task<int> UpdateAuthor(string authorId, Author author)
        {
             int DbResult = 0;
             int upAuthorId = Convert.ToInt32(authorId);
             int Author_author_id = Convert.ToInt32(author.Id);
             AuthorMsSql updatingAuthor = null;
             updatingAuthor = await db.Authors.FindAsync(upAuthorId);

             if (upAuthorId == Author_author_id && dataReqiered.IsDataRequered(author))
             {
                 updatingAuthor.Name = author.Name;
                 updatingAuthor.Surname = author.Surname;
                 db.Entry(updatingAuthor).State = EntityState.Modified;
                 DbResult = await db.SaveChangesAsync();
             }
             return DbResult;
        }

        public async Task<int> DeleteAuthor(string authorId)
        {
             int DbResult = 0;
             int delAuthorId = Convert.ToInt32(authorId);
             AuthorMsSql author = await db.Authors.FindAsync(delAuthorId);

             if (author != null)
             {
                 db.Authors.Remove(author);
                 DbResult = await db.SaveChangesAsync();
             }
             return DbResult;
        }
    }
}
