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

        // GET: api/Test
        [Route("anexo/empresa/{pintCodEmpresa}")]
        public ResultModel GetListadoContratoAnexo(int pintCodEmpresa, [FromUri] string token)
        {
            ContratoManager entityManager = new ContratoManager();
            return entityManager.GetListadoContratosAnexo(token, pintCodEmpresa);
        }
    }
}
