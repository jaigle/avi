using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.DataAccess.Entities;

namespace WebAPI.DataAccess.Repositories
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        Task<IEnumerable<Customer>> GetAllCustomer();
    }
}
