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
    public class EmpresaController : ApiController
    {
        // GET: api/Empresa
        //public ResultModel GetComunas([FromUri] string token)
        public ResultModel GetEmpresa(string pstrRut, int pintNumCliente)
        {
            EmpresaManager empresaManager = new EmpresaManager();
            return empresaManager.GetEmpresa(pstrRut, pintNumCliente);
        }

        // PUT: api/Empresa
        public ResultModel PutMantencion([FromBody]Empresa_put value)
        {
            EmpresaManager empresaManager = new EmpresaManager();
            return empresaManager.ActualizarEmpresa(value);
        }
    }
}
