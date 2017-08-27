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
        public async Task<HttpResponseMessage> CreateAuthor([FromBody] Author author)
        {
            HttpResponseMessage result = await repository.CreateAuthor(author);
            return result;
        }

        [HttpPut]
        public async Task<HttpResponseMessage> UpdateAuthor(string id, [FromBody] Author author)
        {
            HttpResponseMessage result = await repository.UpdateAuthor(id, author);
            return result;
        }

        [HttpDelete]
        public async Task<HttpResponseMessage> DeleteAuthor(string id)
        {
            HttpResponseMessage result = await repository.DeleteAuthor(id);
            return result;
        }
    }
}