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
    public class AnexoController : ApiController
    {
        // GET: api/Test
        //public ResultModel GetComunas([FromUri] string token)
        [Route("api/anexo/{pintIdAnexo}")]
        public ResultModel GetAnexo(int pintIdAnexo)
        {
            AnexoManager anexoManager = new AnexoManager();
            return anexoManager.GetAnexo(pintIdAnexo, String.Empty);
        }
    }
}
