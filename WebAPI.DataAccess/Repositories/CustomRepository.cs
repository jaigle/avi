using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using WebAPI.DataAccess.Entities;
using WebAPI.DataAccess.Infrastructure;

namespace WebAPI.DataAccess.Repositories
{
    public class CustomRepository : GenericRepository<Customer>, ICustomerRepository
    {
        IConnectionFactory _connectionFactory;


        public CustomRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomer()
        {
            var query = "GetAllCustomers";
            var list = await SqlMapper.QueryAsync<Customer>(_connectionFactory.GetConnection, query, commandType: CommandType.StoredProcedure);
            return list;
        }
    }
}
