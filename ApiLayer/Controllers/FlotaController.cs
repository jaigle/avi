using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ApiLayer.Library;
using Test.Entities;

namespace ApiLayer.Controllers
{
    [RoutePrefix("api/flota")]
    public class FlotaController : ApiController
    {
        // GET: api/Test
        //public ResultModel GetComunas([FromUri] string token)
        [Route("cliente/{pintCliente}/{pintContrato:int}/grupoVehiculo/{pintGrupoVehiculo}")]
        [ResponseType(typeof(ResultModel))]
        public ResultModel GetListadoFlota(int pintCliente, int pintContrato, int pintGrupoVehiculo)
        {
            FlotaManager flotaManager = new FlotaManager();
            return flotaManager.GetListadoFlota(pintCliente, pintContrato, pintGrupoVehiculo, String.Empty);
        }
    }
}
