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
    [RoutePrefix("api/infraccion")]
    public class InfraccionController : ApiController
    {
        [Route("cliente/{pintIdCliente}/patente/{pstrPatente}")]
        public ResultModel GetInfracciones(int pintIdCliente, string pstrPatente, [FromUri] string token)
        {
            InfraccionManager infraccionManager = new InfraccionManager();
            return infraccionManager.GetInfracciones(pintIdCliente, pstrPatente, token);
        }
    }
}
