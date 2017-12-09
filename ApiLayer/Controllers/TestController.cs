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
    public class TestController : ApiController
    {
        
     
    // GET: api/Test
    public ResultModel  GetUsers([FromUri] string token)
        {
           UserManager userManager=new UserManager();
            return userManager.GetUsers(token);
        }

        // GET: api/Test/ADMIN
        [Route("api/Test/{id}")]
        public ResultModel Get(string id, [FromUri] string token)
        {
            UserManager userManager = new UserManager();
            return userManager.GetUsersByRol(token,id);
        }

        // POST: api/Test
        [Route("api/Test/Auth")]
        public ResultModel Post([FromBody]LoginModel data)
        {
            AuthManager authManager = new AuthManager();
            return authManager.Authenticate(data);
        }

    }
}
