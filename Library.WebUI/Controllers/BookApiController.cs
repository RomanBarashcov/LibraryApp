using Library.Domain.Abstracts;
using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace Library.WebUI.Controllers
{
    public class BookApiController : BaseApiController
    {
        private IBookRepository repository;
        public BookApiController(IBookRepository bookRepository)
        {
            this.repository = bookRepository;
        }

        // GET api/values
        public HttpResponseMessage GetBooks()
        {
            return ToJson(repository.GetAllBooks().AsEnumerable());
        }

        // GET api/values/5
        public HttpResponseMessage GetBook(int bookId)
        {
            return ToJson(repository.GetBookById(bookId));
        }

        // POST api/values
        public void CreateBook(Book book)
        {
            repository.CreateBook(book);
        }

        // PUT api/values/5
        public void UpdateBook(int bookId, Book book)
        {
            repository.UpdateBook(bookId, book);
        }

        // DELETE api/values/5
        public void DeleteBook(int bookId)
        {
            repository.DeleteBook(bookId);
        }
    }
}