using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ApiLayer.Library;
using Test.Entities;

namespace ApiLayer.Controllers
{
    [RoutePrefix("api/taller")]
    public class TallerController : ApiController
    {
        // GET: api/Test
        [Route("")]
        public ResultModel GetTalleres([FromUri] string token)
        {
            TallerManager talleresManager = new TallerManager();
            return talleresManager.GetTalleres(token);
        }
    }
}
