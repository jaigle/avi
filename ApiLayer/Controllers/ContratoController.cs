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
        //public ResultModel GetComunas([FromUri] string token)
        [Route("empresa/{pintCodEmpresa}/cliente/{pintClienteNumero}")]
        public ResultModel GetListadoContrato(int pintCodEmpresa, int pintClienteNumero)
        {
            ContratoManager entityManager = new ContratoManager();
            return entityManager.GetListadoContratos(String.Empty, pintCodEmpresa, pintClienteNumero);
        }
    }
}
