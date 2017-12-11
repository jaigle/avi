using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Test.Entities;
using WebAPI.Model;
using WebAPI.Repository;

namespace ApiLayer.Library
{
    public class CustomerManager : BaseManager
    {
        private ICustomerRepository _customerRepository;

        //public CustomerManager()
        //{
        //    _customerRepository = new CustomRepository();
        //}


        public ResultModel GetAllCustomers(string token)
        {
            ResultModel resultModel = CheckToken(token);
            if (resultModel.Result)
            {
                resultModel.Payload = Tools.Base64Encode(JsonConvert.SerializeObject(_customerRepository.GetAllCustomers()));
            }
            return resultModel;
        }

        public ResultModel GetCustomerById(int id, string token)
        {
            //ResultModel resultModel = CheckToken(token);
            //if (resultModel.Result)
            //{
            //    Customer aCustomer = _customerRepository.GetAllCustomer(id);
            //    resultModel.Payload = Tools.Base64Encode(JsonConvert.SerializeObject(aCustomer));
            //}
            //return resultModel;
            return null;
        }

        public void AddCustomer(Customer aCustomer)
        {
            //_customerRepository.AddCustomer(aCustomer);
        }
    }
}
