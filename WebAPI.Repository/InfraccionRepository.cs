using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using WebAPI.DataAccess.Infrastructure;
using WebAPI.Model;

namespace WebAPI.Repository
{
    public class InfraccionRepository : GenericRepository<Infraccion>, IInfraccionRepository
    {
        public InfraccionRepository()
        {
            ConnectionFactoryAvis myConection = new ConnectionFactoryAvis();
            _cnx = myConection.GetConnection;
        }

        public Infraccion Get(int pintIdCliente, string pstrPatente)
        {
            Error myError = new Error();
            try
            {
                var query = "Drilo_Infracciones_Select";
                DynamicParameters p = new DynamicParameters();
                p.Add(name: "@IdCliente", value: pintIdCliente, dbType: DbType.Int32);
                p.Add(name: "@Patente", value: pstrPatente, dbType: DbType.String);
                p.Add(name: "@DescError", dbType: DbType.String, direction: ParameterDirection.Output, size: 1000);
                p.Add(name: "@NumError", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                IEnumerable<Infraccion> list = _cnx.Query<Infraccion>(sql: query, param: p, commandType: CommandType.StoredProcedure);
                myError.ErrorCode = p.Get<int>(name: "@NumError");
                myError.ErrorMessage = p.Get<string>(name: "@DescError");
                return myError.ErrorCode > 0 ? throw new CustomException(message: myError.ErrorMessage, localError: myError) : list.First();
            }
            catch (Exception e)
            {
                throw new Exception(message: $"Error obteniendo Infraccion: {e.Message}");
            }
        }

        public IEnumerable<Infraccion> GetListaInfracciones(int pintIdCliente, string pstrPatente)
        {
            Error myError = new Error();
            try
            {
                var query = "Drilo_Infracciones_Select";
                DynamicParameters p = new DynamicParameters();
                p.Add(name: "@IdCliente", value: pintIdCliente, dbType: DbType.Int32);
                p.Add(name: "@Patente", value: pstrPatente, dbType: DbType.String);
                p.Add(name: "@DescError", dbType: DbType.String, direction: ParameterDirection.Output, size: 1000);
                p.Add(name: "@NumError", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                IEnumerable<Infraccion> list = _cnx.Query<Infraccion>(sql: query, param: p, commandType: CommandType.StoredProcedure);
                myError.ErrorCode = p.Get<int>(name: "@NumError");
                myError.ErrorMessage = p.Get<string>(name: "@DescError");
                return myError.ErrorCode > 0 ? throw new CustomException(message: myError.ErrorMessage, localError: myError) : list;
            }
            catch (Exception e)
            {
                throw new Exception(message: $"Error obteniendo listado de Infracciones: {e.Message}");
            }
        }
    }
}
