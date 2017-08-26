using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Helper
{
    public class MssqlAuthorDataHelper
    {
        private List<AuthorMsSql> Authotrs = new List<AuthorMsSql>();
        private AuthorMsSql AuthorMssql = new AuthorMsSql();
        private Author authorsNode = new Author();
        private List<Author> ListAuthor = new List<Author>();
        private IEnumerable<Author> result = null;

        public MssqlAuthorDataHelper(List<AuthorMsSql> authors)
        {
            Authotrs = authors;
        }

        public IEnumerable<Author> GetIEnumerubleDbResult()
        {
            foreach (AuthorMsSql a in Authotrs)
            {
                AuthorMssql = new AuthorMsSql { Id = a.Id, Name = a.Name, Surname = a.Surname };
                authorsNode = new Author(AuthorMssql);
                ListAuthor.Add(authorsNode);
                result = ListAuthor;
            }

            return result;
        }
    }
}
