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
        //public ResultModel GetComunas([FromUri] string token)
        [Route("")]
        public ResultModel GetCiudades()
        {
            CiudadManager ciudadManager = new CiudadManager();
            return ciudadManager.GetCiudades(String.Empty);
        }
    }
}
