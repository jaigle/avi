using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Model;
using WebAPI.Service;

namespace WebAPI.Service
{
    public interface IEntityService<T> : IService
     where T : BaseEntity
    {
        void Create(T entity);
        void Delete(T entity);
        IEnumerable<T> GetAll();      
        void Update(T entity);
    }
}
