﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ApiLayer.Library;
using Test.Entities;

namespace ApiLayer.Controllers
{
    public class ComunaController : ApiController
    {
        // GET: api/Test
        //public ResultModel GetComunas([FromUri] string token)
        [Route("api/comunas/")]
        public ResultModel GetComunas()
        {
            ComunaManager comunaManager = new ComunaManager();
            return comunaManager.GetComunas();
        }
    }
}
