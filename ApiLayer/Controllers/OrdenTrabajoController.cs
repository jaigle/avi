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
    [RoutePrefix("api/ordentrabajo")]
    public class OrdenTrabajoController : ApiController
    {
        [Route("cliente/{pintIdCliente}/patente/{pstrPatente}")]
        public ResultModel GetOrdenesTrabajo(int pintIdCliente, string pstrPatente, [FromUri] string token)
        {
            OrdenTrabajoManager ordenTrabajoManager = new OrdenTrabajoManager();
            return ordenTrabajoManager.GetOrdenesTrabajo(pintIdCliente, pstrPatente, token);
        }
    }
}
