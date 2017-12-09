using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Dapper;
using WebAPI.DataAccess.Infrastructure;
using WebAPI.Model;

namespace WebAPI.Repository
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository()
        {
            ConnectionFactory myConection = new ConnectionFactory();
            _cnx = myConection.GetConnection;
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            var query = "GetAllCustomers";
            var list = await SqlMapper.QueryAsync<DataAccess.Entities.Customer>(_cnx, query, commandType: CommandType.StoredProcedure);
            return (IEnumerable<Customer>) list;
        }

        public IEnumerable<Customer> FindBy(Expression<Func<Customer, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Customer Add(Customer entity)
        {
            throw new NotImplementedException();
        }

        public Customer Delete(Customer entity)
        {
            throw new NotImplementedException();
        }

        public void Edit(Customer entity)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public Customer GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Customer>> GetAllCustomer()
        {
            throw new NotImplementedException();
        }
    }
}