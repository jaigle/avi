using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Model;

namespace WebAPI.Repository
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        Customer GetById(int id);
    }
}
