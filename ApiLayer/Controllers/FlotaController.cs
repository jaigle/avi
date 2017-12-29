﻿using System;
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
        [Route("cliente/{pintCliente}/grupoVehiculo/{pintGrupoVehiculo}")]
        [ResponseType(typeof(ResultModel))]
        public ResultModel GetListadoFlota(int pintCliente, int pintGrupoVehiculo, [FromUri] string token)
        {
            FlotaManager flotaManager = new FlotaManager();
            return flotaManager.GetListadoFlota(pintCliente, pintGrupoVehiculo, token);
        }
    }
}
