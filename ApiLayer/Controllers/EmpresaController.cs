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
    [RoutePrefix("api/empresa")]
    public class EmpresaController : ApiController
    {
        // GET: api/Empresa
        [Route("rut/{pstrRut}/cliente/{pintNumCliente}")]
        public ResultModel GetEmpresa(string pstrRut, int pintNumCliente, [FromUri] string token)
        {
            EmpresaManager empresaManager = new EmpresaManager();
            return empresaManager.GetEmpresa(pstrRut, pintNumCliente, token);
        }

        [Route("")]
        public ResultModel PutEmpresa([FromBody]Empresa_put value, [FromUri] string token)
        {
            EmpresaManager empresaManager = new EmpresaManager();
            return empresaManager.ActualizarEmpresa(value, token);
        }
    }
}
