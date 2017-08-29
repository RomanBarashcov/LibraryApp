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
            int DbResult = 0;
            HttpResponseMessage RespMessage = new HttpResponseMessage(HttpStatusCode.BadRequest);
            if (author != null)
            {
                DbResult = await repository.CreateAuthor(author);
                if(DbResult != 0)
                {
                    RespMessage = new HttpResponseMessage(HttpStatusCode.Created);
                }
            }
            return RespMessage;
        }

        [HttpPut]
        public async Task<HttpResponseMessage> UpdateAuthor(string id, [FromBody] Author author)
        {
            int DbResult = 0;
            HttpResponseMessage RespMessage = new HttpResponseMessage(HttpStatusCode.BadRequest);
            if(!String.IsNullOrEmpty(id) && author != null)
            {
                DbResult = await repository.UpdateAuthor(id, author);
                if(DbResult != 0)
                {
                    RespMessage = new HttpResponseMessage(HttpStatusCode.Created);
                }
            }
            return RespMessage;
        }

        [HttpDelete]
        public async Task<HttpResponseMessage> DeleteAuthor(string id)
        {
            int DbResult = 0;
            HttpResponseMessage RespMessage = new HttpResponseMessage(HttpStatusCode.BadRequest);
            if (!String.IsNullOrEmpty(id))
            {
                DbResult = await repository.DeleteAuthor(id);
                if(DbResult != 0)
                {
                    RespMessage = new HttpResponseMessage(HttpStatusCode.OK);
                }
            }
            return RespMessage;
        }
    }
}