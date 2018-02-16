using System;
using System.Collections.Generic;
using System.Data;
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
            throw new NotImplementedException();
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

        public IEnumerable<Customer> GetAllCustomers()
        {
            var query = "Drilo_GetAllCustomers";
            var list = _cnx.Query<Customer>(sql: query, commandType: CommandType.StoredProcedure);
            return list;
        }
    }
}