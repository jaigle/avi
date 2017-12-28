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
        //[Route("{pstrToken}")]
        //public ResultModel GetCiudades(string pstrToken)
        //{
        //    CiudadManager ciudadManager = new CiudadManager();
        //    return ciudadManager.GetCiudades(pstrToken);
        //}

        [Route("")]
        public ResultModel GetCiudades2([FromUri] string token)
        {
            CiudadManager ciudadManager = new CiudadManager();
            return ciudadManager.GetCiudades(token);
        }
    }
}
