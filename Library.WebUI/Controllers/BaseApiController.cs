using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;

namespace Library.WebUI.Controllers
{
    public class BaseApiController : ApiController
    {
        protected HttpResponseMessage ToJson(dynamic obj)
        {
            var response = Request.CreateResponse(System.Net.HttpStatusCode.OK);
            response.Content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
            return response;
        }
    }
}