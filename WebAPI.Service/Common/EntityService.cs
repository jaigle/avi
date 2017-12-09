using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Model;
using WebAPI.Repository;

namespace WebAPI.Service
{
    public abstract class EntityService<T> : IEntityService<T> where T : BaseEntity
    {
        IGenericRepository<T> _repository;

        public EntityService(IGenericRepository<T> repository)
        {
            _repository = repository;
        }


        public virtual void Create(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _repository.Add(entity);
        }


        public virtual void Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            _repository.Edit(entity);
        }

        public virtual void Delete(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            _repository.Delete(entity);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _repository.GetAllAsync();
        }
    }
}
