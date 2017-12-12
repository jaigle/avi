using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Dapper;
using WebAPI.DataAccess.Infrastructure;
using WebAPI.Model;
using WebAPI.SQL;

namespace WebAPI.Repository
{
    class MantencionRepository : GenericRepository<Mantencion>, IMantencionRepository
    {
        public MantencionRepository()
        {
            ConnectionFactoryAvis myConection = new ConnectionFactoryAvis();
            _cnx = myConection.GetConnection;
        }

        public IEnumerable<Mantencion> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Mantencion> FindBy(Expression<Func<Mantencion, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Mantencion Add(Mantencion entity)
        {
            throw new NotImplementedException();
        }

        public Mantencion Delete(Mantencion entity)
        {
            throw new NotImplementedException();
        }

        public void Edit(Mantencion entity)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Mantencion> GetListaMantencion()
        {
            var query = Consultas.SqlText.Comuna_Select;
            var list = _cnx.Query<Mantencion>(query);
            return list;
        }
    }
}
