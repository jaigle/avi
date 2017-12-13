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
    public class MantencionController : ApiController
    {
        // PUT: api/Mantencion
        public ResultModel PutMantencion([FromBody]Mantencion value)
        {
            MantencionManager mantencionManager = new MantencionManager();
            return mantencionManager.ActualizarMantencion(value);
        }

        // POST: api/Mantencion
        public ResultModel PostMantencion([FromBody]Mantencion value)
        {
            MantencionManager mantencionManager = new MantencionManager();
            return mantencionManager.AgregarMantencion(value);
        }

        // GET: api/Mantencion/{Agenda}{CodigoCliente}
        public ResultModel GetListMantencion(int pintIdAgenda, int pintCodCliente)
        {
            MantencionManager mantencionManager = new MantencionManager();
            return mantencionManager.GetListadoMantencion(pintIdAgenda, pintCodCliente);
        }

        // GET: api/Mantencion/{Agenda}{CodigoCliente}
        [Route("api/Disponibilidad")]
        public ResultModel GetDisponibilidad(int pintIdTaller, DateTime pFecha)
        {
            MantencionManager mantencionManager = new MantencionManager();
            return mantencionManager.GetDisponibilidad(pintIdTaller, DateTime.Today);
        }
    }
}
