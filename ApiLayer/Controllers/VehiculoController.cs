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
        //public ResultModel GetComunas([FromUri] string token)
        [Route("patente/{pstrPatente}")]
        public ResultModel GetVehiculo(string pstrPatente)
        {
            VehiculoManager vehiculoManager = new VehiculoManager();
            return vehiculoManager.GetVehiculo(pstrPatente, string.Empty);
        }
    }
}
