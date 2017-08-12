using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Entities
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public ICollection<Book> books { get; set; }
        public Author()
        {
            books = new List<Book>();
        }
    }
}
