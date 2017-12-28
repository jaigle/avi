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
        //public ResultModel GetComunas([FromUri] string token)
        [Route("")]
        public ResultModel GetTalleres()
        {
            TallerManager talleresManager = new TallerManager();
            return talleresManager.GetTalleres(string.Empty);
        }
    }
}
