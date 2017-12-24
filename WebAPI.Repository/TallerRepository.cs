using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using Dapper;
using WebAPI.DataAccess.Infrastructure;
using WebAPI.Model;
using static WebAPI.SQL.Consultas;

namespace WebAPI.Repository
{
    public class TallerRepository : GenericRepository<Taller>, ITallerRepository
    {
        public TallerRepository()
        {
            ConnectionFactoryAvis myConection = new ConnectionFactoryAvis();
            _cnx = myConection.GetConnection;
        }


        public IEnumerable<Taller> GetListaTalleres()
        {
            var query = SqlText.Taller_Select;
            var list = _cnx.Query<Taller>(sql: query);
            return list;
        }

        public IEnumerable<Comuna> GetAllAsync()
        {
            throw new NotImplementedException();
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
    }
}