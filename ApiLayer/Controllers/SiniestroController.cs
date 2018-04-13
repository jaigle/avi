using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ApiLayer.Library;
using Test.Entities;
using WebAPI.Model;

namespace ApiLayer.Controllers
{
    [RoutePrefix("api")]
    public class SiniestroController : ApiController
    {
        // POST: api/siniestro
        [Route("siniestro")]
        public ResultModel Post([FromBody]Siniestro value, [FromUri] string token)
        {
            SiniestroManager siniestroManager = new SiniestroManager();
            return siniestroManager.AddSiniestro(value, token);
        }

        // POST: api/siniestrofoto
        [Route("siniestrofoto")]
        public ResultModel Post([FromBody]SiniestroFoto value, [FromUri] string token)
        {
            SiniestroManager siniestroManager = new SiniestroManager();
            return siniestroManager.AddSiniestroFoto(value, token);
        }

        // POST: api/siniestrotercero
        [Route("siniestrotercero")]
        public ResultModel Post([FromBody]SiniestroTercero value, [FromUri] string token)
        {
            SiniestroManager siniestroManager = new SiniestroManager();
            return siniestroManager.AddTercero(value, token);
        }
    }
}
