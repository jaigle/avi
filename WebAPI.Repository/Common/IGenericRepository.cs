using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Model;

namespace WebAPI.Repository
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAllAsync();
        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);
        T Add(T entity);
        T Delete(T entity);
        void Edit(T entity);
        void Save();
    }
}
