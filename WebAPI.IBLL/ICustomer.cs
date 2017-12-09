using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebAPI.DataAccess.Entities;

namespace WebAPI.IBLL
{
    public interface ICustomer
    {
        Task<IEnumerable<Customer>> getCustomersList();
    }
}
