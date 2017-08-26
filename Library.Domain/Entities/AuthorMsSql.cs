using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Entities
{
    public class AuthorMsSql
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public ICollection<BookMsSql> books { get; set; }
        public AuthorMsSql()
        {
            books = new List<BookMsSql>();
        }
    }
}
