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
        //public ResultModel GetComunas([FromUri] string token)
        [Route("rut/{pstrRut}/cliente/{pintNumCliente}")]
        public ResultModel GetEmpresa(string pstrRut, int pintNumCliente)
        {
            EmpresaManager empresaManager = new EmpresaManager();
            return empresaManager.GetEmpresa(pstrRut, pintNumCliente);
        }

        //// PUT: api/Empresa
        //[Route("")]
        //public ResultModel PutMantencion([FromBody]Empresa_put value)
        //{
        //    EmpresaManager empresaManager = new EmpresaManager();
        //    return empresaManager.ActualizarEmpresa(value);
        //}

        [Route("")]
        public ResultModel PutEmpresa([FromBody]Empresa_put value)
        {
            EmpresaManager empresaManager = new EmpresaManager();
            return empresaManager.ActualizarEmpresa(value);
        }
    }
}
