using Library.Domain.Abstracts;
using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Library.WebUI.Controllers
{
    public class BookApiController : BaseApiController
    {
        private IBookRepository repository;
        public BookApiController(IBookRepository bookRepository)
        {
            this.repository = bookRepository;
        }

        public async Task<HttpResponseMessage> GetBooks()
        {
            IEnumerable<Book> Books = await repository.GetAllBooks();
            return ToJson(Books);
        }

        [HttpPost]
        public void CreateBook([FromBody] Book book)
        {
            repository.CreateBook(book);
        }

        [HttpPut]
        public void UpdateBook(string id, [FromBody] Book book)
        {
            repository.UpdateBook(id, book);
        }

        [HttpDelete]
        public void DeleteBook(string id)
        {
            repository.DeleteBook(id);
        }

        [Route("BookApi/GetBookByAuthorId/{id}")]
        public async Task<HttpResponseMessage> GetBookByAuthorId(string id)
        {
            IEnumerable<Book> Books = await repository.GetBookByAuthorId(id);
            return ToJson(Books);
        }
    }
}