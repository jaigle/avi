using System.Collections.Generic;
using WebAPI.Model;

namespace WebAPI.Repository
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        Customer GetById(int id);
        IEnumerable<Customer> GetAllCustomers();
    }
}
