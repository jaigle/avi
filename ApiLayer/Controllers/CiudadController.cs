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
    [RoutePrefix("api/ciudad")]
    public class CiudadController : ApiController
    {
        // GET: api/Test
        [Route("nada/{pstrToken}")]
        public ResultModel GetComunas(string pstrToken)
        {
            CiudadManager ciudadManager = new CiudadManager();
            return ciudadManager.GetCiudades(pstrToken);
        }
    }
}
