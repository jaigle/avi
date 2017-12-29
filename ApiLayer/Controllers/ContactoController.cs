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
    [RoutePrefix("api/contacto")]
    public class ContactoController : ApiController
    {
        // GET: api/TipoContacto
        [Route("tipoContacto/")]
        public ResultModel GetListTipoContacto([FromUri] string token)
        {
            ContactoManager contactoManager = new ContactoManager();
            return contactoManager.GetListTipoContacto(token);
        }

        // GET: api/Contacto/5
        [Route("contactoEmpresa/{idEmpresa:int?}")]
        public ResultModel GetContactoPorEmpresa([FromUri] string token, int idEmpresa = 0)
        {
            ContactoManager contactoManager = new ContactoManager();
            return contactoManager.GetContactoPorEmpresa(idEmpresa, token);
        }

        [Route("deletecontactoCliente2")]
        public ResultModel DeleteContactoPorEmpresa2([FromBody]ContactoCliente value, [FromUri] string token)
        {
            ContactoManager contactoManager = new ContactoManager();
            return contactoManager.DeleteContactClient(value, token);
        }

        [Route("deletecontactoCliente/contacnum/{pintContacNum}/clientenum/{pintClienteNum}/tipocontacto/{pintTipoContacto}")]
        public ResultModel DeleteContactoPorEmpresa(int pintContacNum, int pintClienteNum, int pintTipoContacto, [FromUri] string token)
        {
            ContactoManager contactoManager = new ContactoManager();
            ContactoCliente miCliente = new ContactoCliente();
            miCliente.contacNumero = pintContacNum;
            miCliente.clienteNumero = pintClienteNum;
            miCliente.idTipoContacto = pintTipoContacto.ToString();

            return contactoManager.DeleteContactClient(miCliente,token);
        }

        // POST: api/Contacto
        [Route("")]
        public ResultModel Post([FromBody]ContactoDto value, [FromUri] string token)
        {
            ContactoManager contactoManager = new ContactoManager();
            return contactoManager.AddContacto(value, token);
        }

        // PUT: api/Contacto/5
        [Route("")]
        public ResultModel Put([FromBody]ContactoCliente value, [FromUri] string token)
        {
            ContactoManager contactoManager = new ContactoManager();
            return contactoManager.PutContactoCliente(value, token);
        }


        [Route("usuario/")]
        public ResultModel GetListUsuarios([FromUri] string token)
        {
            ContactoManager contactoManager = new ContactoManager();
            return contactoManager.GetListUsuarios(token);
        }
    }
}
