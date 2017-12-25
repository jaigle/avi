using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Routing;
using ApiLayer.Library;
using Test.Entities;

namespace ApiLayer.Controllers
{
    public class SecController : ApiController
    {

        // POST: api/Test
        [Route("api/Sec/Auth")]
        public ResultModel Post([FromBody]LoginModel data)
        {
            AuthManager authManager = new AuthManager();
            return authManager.Authenticate(data);
        }
    }
}
