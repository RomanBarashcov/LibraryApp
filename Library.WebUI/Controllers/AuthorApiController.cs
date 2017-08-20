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
    public class AuthorApiController : BaseApiController
    {
        private IAuthorRepository repository;
        public AuthorApiController(IAuthorRepository authorRepository)
        {
            this.repository = authorRepository;
        }

        public HttpResponseMessage GetAuthors()
        {
            return ToJson(repository.GetAllAuthors().AsEnumerable());
        }

        public HttpResponseMessage GetAuthor(int id)
        {
            return ToJson(repository.GetAuthorById(id));
        }

        [HttpPost]
        public void CreateAuthor([FromBody] Author author)
        {
            repository.CreateAuthor(author);
        }

        [HttpPut]
        public void UpdateAuthor(int id, [FromBody] Author author)
        {
            repository.UpdateAuthor(id, author);
        }

        [HttpDelete]
        public void DeleteAuthor(int id)
        {
            repository.DeleteAuthor(id);
        }
    }
}