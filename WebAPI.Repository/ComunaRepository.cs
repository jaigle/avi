using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Dapper;
using WebAPI.DataAccess.Infrastructure;
using WebAPI.Model;
using static WebAPI.SQL.Consultas;

namespace WebAPI.Repository
{
    public class ComunaRepository : GenericRepository<Comuna>, IComunaRepository
    {
        public ComunaRepository()
        {
            ConnectionFactoryAvis myConection = new ConnectionFactoryAvis();
            _cnx = myConection.GetConnection;
        }

        public IEnumerable<Comuna> GetAll()
        {
            try
            {
                var query = SqlText.Comuna_Select;
                var list = _cnx.Query<Comuna>(query);
                return list;
            }
            catch (Exception e)
            {
                throw new Exception("Error obteniendo Listado de Comunas de Contactos: " + e.Message);
            }
        }

        public IEnumerable<Comuna> FindBy(Expression<Func<Comuna, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Comuna Add(Comuna entity)
        {
            throw new NotImplementedException();
        }

        public Comuna Delete(Comuna entity)
        {
            throw new NotImplementedException();
        }

        public void Edit(Comuna entity)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Comuna> GetListaComunas()
        {
            throw new NotImplementedException();
        }
    }
}