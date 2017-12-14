﻿using System;
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
    [RoutePrefix("api/mantencion")]
    public class MantencionController : ApiController
    {
        // PUT: api/Mantencion
        [Route("")]
        public ResultModel PutMantencion([FromBody]Mantencion value)
        {
            MantencionManager mantencionManager = new MantencionManager();
            return mantencionManager.ActualizarMantencion(value);
        }

        // POST: api/Mantencion
        [Route("")]
        public ResultModel PostMantencion([FromBody]Mantencion value)
        {
            MantencionManager mantencionManager = new MantencionManager();
            return mantencionManager.AgregarMantencion(value);
        }

        // GET: api/Mantencion/{Agenda}{CodigoCliente}
        [Route("Listado/{pintIdAgenda:int}/{pintCodCliente:int}")]
        public ResultModel GetListMantencion(int pintIdAgenda, int pintCodCliente)
        {
            MantencionManager mantencionManager = new MantencionManager();
            return mantencionManager.GetListadoMantencion(pintIdAgenda, pintCodCliente);
        }

        // GET: api/Mantencion/{Agenda}{CodigoCliente}
        [Route("Disponibilidad/{pintIdTaller:int}/{pFecha:datetime:regex(\\d{4}-\\d{2}-\\d{2})}")]
        public ResultModel GetDisponibilidad(int pintIdTaller, DateTime pFecha)
        {
            MantencionManager mantencionManager = new MantencionManager();
            return mantencionManager.GetDisponibilidad(pintIdTaller, DateTime.Today);
        }
    }
}