using Library.Domain.Abstracts;
using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

        public HttpResponseMessage GetBooks()
        {
            return ToJson(repository.GetAllBooks().AsEnumerable());
        }

        public HttpResponseMessage GetBook(int id)
        {
            return ToJson(repository.GetBookById(id));
        }

        [HttpPost]
        public void CreateBook([FromBody] Book book)
        {
            repository.CreateBook(book);
        }

        [HttpPut]
        public void UpdateBook(int id, [FromBody] Book book)
        {
            repository.UpdateBook(id, book);
        }

        [HttpDelete]
        public void DeleteBook(int id)
        {
            repository.DeleteBook(id);
        }

        [Route("BookApi/GetBookByAuthorId/{id}")]
        public HttpResponseMessage GetBookByAuthorId(int id)
        {
            return ToJson(repository.GetBookByAuthorId(id).AsEnumerable());
        }
    }
}