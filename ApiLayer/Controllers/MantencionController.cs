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
    [RoutePrefix("api/mantencion")]
    public class MantencionController : ApiController
    {
        // PUT: api/Mantencion
        [Route("")]
        public ResultModel PutMantencion([FromBody]Mantencion value, [FromUri] string token)
        {
            MantencionManager mantencionManager = new MantencionManager();
            return mantencionManager.ActualizarMantencion(value, token);
        }

        // POST: api/Mantencion
        [Route("")]
        public ResultModel PostMantencion([FromBody]Mantencion value, [FromUri] string token)
        {
            MantencionManager mantencionManager = new MantencionManager();
            return mantencionManager.AgregarMantencion(value, token);
        }

        // GET: api/Mantencion/{Agenda}{CodigoCliente}
        [Route("agenda/{pintIdAgenda:int}/cliente/{pintCodCliente:int}")]
        public ResultModel GetListMantencion(int pintIdAgenda, int pintCodCliente, [FromUri] string token)
        {
            MantencionManager mantencionManager = new MantencionManager();
            return mantencionManager.GetListadoMantencion(pintIdAgenda, pintCodCliente, token);
        }

        // GET: api/Mantencion/{Agenda}{CodigoCliente}
        [Route("taller/{pintIdTaller}/fecha/{pFecha}")]
        public ResultModel GetDisponibilidad(int pintIdTaller, string pFecha, [FromUri] string token)
        {
            MantencionManager mantencionManager = new MantencionManager();
            return mantencionManager.GetDisponibilidad(pintIdTaller, pFecha, token);
        }
    }
}
