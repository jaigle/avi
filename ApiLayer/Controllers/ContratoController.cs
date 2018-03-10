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
    [RoutePrefix("api/contrato")]
    public class ContratoController : ApiController
    {
        // GET: api/Test
        [Route("empresa/{pintCodEmpresa}")]
        public ResultModel GetListadoContrato(int pintCodEmpresa, [FromUri] string token)
        {
            ContratoManager entityManager = new ContratoManager();
            return entityManager.GetListadoContratos(token, pintCodEmpresa);
        }

        // GET: api/anexo
        [Route("anexo/empresa/{pintCodEmpresa}")]
        public ResultModel GetListadoContratoAnexo(int pintCodEmpresa, [FromUri] string token)
        {
            ContratoManager entityManager = new ContratoManager();
            return entityManager.GetListadoContratosAnexo(token, pintCodEmpresa);
        }


        // GET: api/EstadoPago
        [Route("estadopago/empresa/{pintCodEmpresa}")]
        public ResultModel GetListadoEstadoPago(int pintCodEmpresa, [FromUri] string token)
        {
            ContratoManager entityManager = new ContratoManager();
            return entityManager.GetListadoEstadoPago(token, pintCodEmpresa);
        }
    }
}
