using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Entities
{
    public class Book
    {
        public string Id { get; set; }
        public int Year { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string AuthorId { get; set; }

        private BookMsSql BooksMssql;
        private BookMongoDb BooksMongoDb;

        public Book(BookMsSql bookMsRef)
        {
            Id = bookMsRef.Id.ToString();
            Year = bookMsRef.Year;
            Name = bookMsRef.Name;
            Description = bookMsRef.Description;
            AuthorId = bookMsRef.AuthorId.ToString();
            BooksMssql = bookMsRef;
        }

        public Book(BookMongoDb bookMongoRef)
        {
            Id = bookMongoRef.Id.ToString();
            Year = bookMongoRef.Year;
            Name = bookMongoRef.Name;
            Description = bookMongoRef.Description;
            AuthorId = bookMongoRef.AuthorId;
            BooksMongoDb = bookMongoRef;
        }

        public Book() { }
    }
}
