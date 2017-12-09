using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using WebAPI.DataAccess.Infrastructure;
using WebAPI.IBLL;

namespace WebAPI.BLL
{
    public class Customer : ICustomer
    {
        private IConnectionFactory _connectionFactory;

        public async Task<IEnumerable<DataAccess.Entities.Customer>> getCustomersList()
        {
            var query = "GetAllCustomers";
            var list = await SqlMapper.QueryAsync<DataAccess.Entities.Customer>(_connectionFactory.GetConnection, query, commandType: CommandType.StoredProcedure);
            return list;
        }
    }
}
