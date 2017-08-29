using Library.Domain.Abstracts;
using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
            int DbResult = 0;
            HttpResponseMessage RespMessage = new HttpResponseMessage(HttpStatusCode.BadRequest);
            if(book != null)
            {
                DbResult = await repository.CreateBook(book);
                if(DbResult != 0)
                {
                    RespMessage = new HttpResponseMessage(HttpStatusCode.Created);
                }
            }
            return RespMessage;
        }

        [HttpPut]
        public async Task<HttpResponseMessage> UpdateBook(string id, [FromBody] Book book)
        {
            int DbResult = 0;
            HttpResponseMessage RespMessage = new HttpResponseMessage(HttpStatusCode.BadRequest);
            if (!String.IsNullOrEmpty(id) && book != null)
            {
                DbResult = await repository.UpdateBook(id, book);
                if(DbResult != 0)
                {
                    RespMessage = new HttpResponseMessage(HttpStatusCode.Created);
                }
            }
            return RespMessage;
        }

        [HttpDelete]
        public async Task<HttpResponseMessage> DeleteBook(string id)
        {
            int DbResult = 0;
            HttpResponseMessage RespMessage = new HttpResponseMessage(HttpStatusCode.BadRequest);
            if (!String.IsNullOrEmpty(id))
            {
                DbResult = await repository.DeleteBook(id);
                if(DbResult != 0)
                {
                    RespMessage = new HttpResponseMessage(HttpStatusCode.OK);
                }
            }
            return RespMessage;
        }

        [Route("BookApi/GetBookByAuthorId/{id}")]
        public async Task<HttpResponseMessage> GetBookByAuthorId(string id)
        {
            IEnumerable<Book> Books = await repository.GetBookByAuthorId(id);
            return ToJson(Books);
        }
    }
}