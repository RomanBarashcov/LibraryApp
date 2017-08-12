using Library.Domain.Abstracts;
using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace Library.WebUI.Controllers
{
    public class AuthorApiController : BaseApiController
    {
        private IAuthorRepository repository;
        public AuthorApiController(IAuthorRepository authorRepository)
        {
            this.repository = authorRepository;
        }

        // GET api/values
        public HttpResponseMessage Get()
        {
            return ToJson(repository.GetAllAuthors().AsQueryable());
        }

        // GET api/values/5
        public HttpResponseMessage Get(int authorId)
        {
            return ToJson(repository.GetAuthorById(authorId));
        }

        // POST api/values
        public void Post(Author author)
        {
            repository.CreateAuthor(author);
        }

        // PUT api/values/5
        public void Put(int authorId, Author author)
        {
            repository.UpdateAuthor(authorId, author);
        }

        // DELETE api/values/5
        public void Delete(int authorId)
        {
            repository.DeleteAuthor(authorId);
        }
    }
}