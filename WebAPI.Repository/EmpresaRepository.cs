using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using Dapper;
using WebAPI.DataAccess.Infrastructure;
using WebAPI.Model;

namespace WebAPI.Repository
{
    public class EmpresaRepository : GenericRepository<Comuna>, IEmpresaRepository
    {
        public EmpresaRepository()
        {
            ConnectionFactoryAvis myConection = new ConnectionFactoryAvis();
            _cnx = myConection.GetConnection;
        }

        public Empresa Get(string pstrRut, int pintNumeroCliente)
        {
            try
            {
                var query = "Cliente_Select_GetEmpresa";
                DynamicParameters p = new DynamicParameters();
                p.Add("@ClienteRut", pstrRut, DbType.String);
                p.Add("@NumeroCliente", pintNumeroCliente);
                IEnumerable<Empresa> list = _cnx.Query<Empresa>(query,p, commandType: CommandType.StoredProcedure);
                return list.First();
            }
            catch (Exception e)
            {
                throw new Exception("Error obteniendo Empresa: " + e.Message);
            }
        }

        public IEnumerable<Empresa> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Empresa> FindBy(Expression<Func<Empresa, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Empresa Add(Empresa entity)
        {
            throw new NotImplementedException();
        }

        public Empresa Delete(Empresa entity)
        {
            throw new NotImplementedException();
        }

        public void Edit(Empresa entity)
        {
            throw new NotImplementedException();
        }

        public void Edit(Empresa_put entity)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
} 