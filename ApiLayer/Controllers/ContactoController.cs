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
    public class ContactoController : ApiController
    {
        // GET: api/TipoContacto
        [Route("api/TipoContacto/")]
        //public ResultModel GetListTipoContacto([FromUri] string token)
        public ResultModel GetListTipoContacto()
        {
            ContactoManager contactoManager = new ContactoManager();
            return contactoManager.GetListTipoContacto(String.Empty);
        }

        // GET: api/Contacto/5
        [Route("api/ContactoEmpresa/{id}")]
        //public ResultModel GetContactoPorEmpresa(int id, [FromUri] string token)
        public ResultModel GetContactoPorEmpresa(int id)
        {
            ContactoManager contactoManager = new ContactoManager();
            return contactoManager.GetContactoPorEmpresa(id, String.Empty);
        }

        [Route("api/ContactoCliente/{id1}/cliente/{id2}")]
        //public ResultModel GetContactoPorEmpresa(int id1, int id2, [FromUri] string token)
        public ResultModel GetContactoPorEmpresa(int id1, int id2)
        {
            ContactoManager contactoManager = new ContactoManager();
            return contactoManager.GetContactoClientePorLlave(id1,id2, String.Empty);
        }

        [Route("api/ContactoCliente/{id1}/cliente/{id2}")]
        //public ResultModel DeleteContactoPorEmpresa(int id1, int id2, [FromUri] string token)
        public ResultModel DeleteContactoPorEmpresa(int id1, int id2)
        {
            ContactoManager contactoManager = new ContactoManager();
            return contactoManager.GetContactoClientePorLlave(id1, id2, String.Empty);
        }

        // POST: api/Contacto
        //public ResultModel Post([FromBody]ContactoDto value, [FromUri] string token)
        public ResultModel Post([FromBody]ContactoDto value)
        {
            ContactoManager contactoManager = new ContactoManager();
            return contactoManager.AddContacto(value, String.Empty);
        }

        // PUT: api/Contacto/5
        //public ResultModel Put([FromBody]ContactoCliente value, [FromUri] string token)
        public ResultModel Put([FromBody]ContactoCliente value)
        {
            ContactoManager contactoManager = new ContactoManager();
            return contactoManager.PutContactoCliente(value, String.Empty);
        }

        // DELETE: api/Contacto/5
        public void Delete(int id)
        {
        }
    }
}
