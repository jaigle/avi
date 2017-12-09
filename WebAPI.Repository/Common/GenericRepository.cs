using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebAPI.DataAccess.Infrastructure;
using WebAPI.Model;

namespace WebAPI.Repository
{
    public abstract class GenericRepository<T> : IGenericRepository<T>
       where T : BaseEntity
    {
        public IDbConnection _cnx;

        public GenericRepository(IDbConnection cnx)
        {
            _cnx = cnx;
        }

        public GenericRepository()
        {
        }

        public IEnumerable<T> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public T Add(T entity)
        {
            throw new NotImplementedException();
        }

        public T Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public void Edit(T entity)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
