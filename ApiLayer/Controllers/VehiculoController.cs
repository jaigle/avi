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
    [RoutePrefix("api/vehiculo")]
    public class VehiculoController : ApiController
    {
        // GET: api/Test/{pstrPatente}
        [Route("patente/{pstrPatente}")]
        public ResultModel GetVehiculo(string pstrPatente, [FromUri] string token)
        {
            VehiculoManager vehiculoManager = new VehiculoManager();
            return vehiculoManager.GetVehiculo(pstrPatente, token);
        }

        [Route("reemplazo/cliente/{idCliente}/patente/{pstrPatente}")]
        public ResultModel GetReemplazos(int idCliente, string pstrPatente, [FromUri] string token)
        {
            VehiculoManager vehiculoManager = new VehiculoManager();
            return vehiculoManager.GetListaReemplazosVehiculo(idCliente, pstrPatente, token);
        }
    }
}
