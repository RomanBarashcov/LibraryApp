using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Concrete
{
     public class LibraryContext : DbContext
     {
            public DbSet<Author> Authors { get; set; }
            public DbSet<Book> Books { get; set; }
     }
    
}
