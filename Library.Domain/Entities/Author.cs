using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Entities
{
    public class Author
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        private AuthorMsSql AuthorsMssql;
        private AuthorMongoDb AuthorsMongoDb;

        public Author(AuthorMsSql authorMsRef)
        {
            Id = authorMsRef.Id.ToString();
            Name = authorMsRef.Name;
            Surname = authorMsRef.Surname;
            AuthorsMssql = authorMsRef;
        }

        public Author(AuthorMongoDb authorMongoRef)
        {
            Id = authorMongoRef.Id;
            Name = authorMongoRef.Name;
            Surname = authorMongoRef.Surname;
            AuthorsMongoDb = authorMongoRef;
        }

        public Author() { }
    }
}
