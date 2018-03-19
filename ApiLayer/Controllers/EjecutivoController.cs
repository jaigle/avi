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
    [RoutePrefix("api/ejecutivo")]
    public class EjecutivoController : ApiController
    {
        // GET: api/Test
        [Route("")]
        public ResultModel GetEjecutivos([FromUri] string token)
        {
            EjecutivoManager ciudadManager = new EjecutivoManager();
            return ciudadManager.GetEjecutivos(token);
        }
    }
}
