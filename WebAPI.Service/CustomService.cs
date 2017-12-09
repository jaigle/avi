using System.Collections.Generic;
using WebAPI.Model;
using WebAPI.Repository;

namespace WebAPI.Service
{
    class CustomService : ICustomService
    {

        ICustomerRepository _customerRepository;


        public void Create(Customer entity)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(Customer entity)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Customer> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public void Update(Customer entity)
        {
            throw new System.NotImplementedException();
        }

        public Customer GetById(int Id)
        {
            return _customerRepository.GetById(Id);
        }
    }
}
