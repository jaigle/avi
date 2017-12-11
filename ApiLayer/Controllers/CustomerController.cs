using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ApiLayer.Library;
using Newtonsoft.Json;
using Test.Entities;
using WebAPI.Repository;

namespace ApiLayer.Controllers
{
    [Route("api/[controller]")]
    public class CustomerController : ApiController
    {
        //ICustomerRepository _icustomerRepository;

        //public CustomerController(ICustomerRepository icustomerRepository)
        //{
        //    this._icustomerRepository = icustomerRepository;
        //}
        CustomerRepository objRepo;

        protected CustomerController()
        {
            objRepo = new CustomerRepository();
        }



        // GET: api/Customer
        public ResultModel GetCustomers([FromUri] string token)
        {
            var listado = objRepo.GetAllCustomers();
            ResultModel resultModel = new ResultModel {Payload = Tools.Base64Encode(JsonConvert.SerializeObject(listado))};
            return resultModel;
        }

        // GET: api/Customer/5
        [Route("api/Customer/{id}")]
        public ResultModel Get(int id, [FromUri] string token) 
        {
            //CustomerManager custManager = new CustomerManager((ICustomerRepository)_customerRepository);
            //return custManager.GetCustomerById(id, token);
            return null;
        }

        // POST: api/Customer
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Customer/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Customer/5
        public void Delete(int id)
        {
        }
    }
}
