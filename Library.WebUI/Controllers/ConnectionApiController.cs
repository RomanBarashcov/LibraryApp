using Library.WebUI.App_Start;
using Library.WebUI.Controllers;
using Library.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Library.WebUI.Controllers
{
    public class ConnectionApiController : ApiController
    {
        public IHttpActionResult Get()
        {
            return Ok();
        }

        public IHttpActionResult Post([FromBody]ConnectionString connectionString)
        {
            NinjectWebCommon.InitConnection(connectionString.connectionDbString);
            return Ok();
        }

    }
}
