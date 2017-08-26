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
    public class AuthorApiController : BaseApiController
    {
        private IAuthorRepository repository;
        public AuthorApiController(IAuthorRepository authorRepository)
        {
            this.repository = authorRepository;
        }

        public async Task<HttpResponseMessage> GetAuthors()
        {
            IEnumerable<Author> Authors = await repository.GetAllAuthors();
            return ToJson(Authors);    
        }

        [HttpPost]
        public void CreateAuthor([FromBody] Author author)
        {
            repository.CreateAuthor(author);
        }

        [HttpPut]
        public void UpdateAuthor(string id, [FromBody] Author author)
        {
            repository.UpdateAuthor(id, author);
        }

        [HttpDelete]
        public void DeleteAuthor(string id)
        {
            repository.DeleteAuthor(id);
        }
    }
}