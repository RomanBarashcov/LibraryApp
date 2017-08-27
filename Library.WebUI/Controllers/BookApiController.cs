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
        public async Task<HttpResponseMessage> CreateBook([FromBody] Book book)
        {
            HttpResponseMessage result = await repository.CreateBook(book);
            return result;
        }

        [HttpPut]
        public async Task<HttpResponseMessage> UpdateBook(string id, [FromBody] Book book)
        {
            HttpResponseMessage result = await repository.UpdateBook(id, book);
            return result;
        }

        [HttpDelete]
        public async Task<HttpResponseMessage> DeleteBook(string id)
        {
            HttpResponseMessage result = await repository.DeleteBook(id);
            return result;
        }

        [Route("BookApi/GetBookByAuthorId/{id}")]
        public async Task<HttpResponseMessage> GetBookByAuthorId(string id)
        {
            IEnumerable<Book> Books = await repository.GetBookByAuthorId(id);
            return ToJson(Books);
        }
    }
}