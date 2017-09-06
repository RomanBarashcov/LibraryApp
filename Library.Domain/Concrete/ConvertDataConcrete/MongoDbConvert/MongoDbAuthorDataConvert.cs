using Library.Domain.Abstracts;
using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Helper
{
    public class MongoDbAuthorDataConvert : IConvertDataHelper<AuthorMongoDb, Author>
    {
        private List<AuthorMongoDb> Authors = new List<AuthorMongoDb>();
        private AuthorMongoDb AuthorMongoDB = new AuthorMongoDb();
        private Author authorNode = new Author();
        private List<Author> ListAuthor = new List<Author>();
        private IEnumerable<Author> result = null;

        public void InitData(List<AuthorMongoDb> authors)
        {
            Authors = authors;
        }

        public IEnumerable<Author> GetIEnumerubleDbResult()
        {
            foreach (AuthorMongoDb b in Authors)
            {
                AuthorMongoDB = new AuthorMongoDb { Id = b.Id, Name = b.Name, Surname = b.Surname };
                authorNode = new Author(AuthorMongoDB);
                ListAuthor.Add(authorNode);
                result = ListAuthor;
            }

            return result;
        }
    }
}
