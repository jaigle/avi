using System.Linq;
using Dapper;
using WebAPI.DataAccess.Infrastructure;
using WebAPI.Model;
using System.Data;
using System.Collections.Generic;
using System;

namespace WebAPI.Repository
{
    public class OrdenTrabajoRepository : GenericRepository<OrdenTrabajo>, IOrdenTrabajoRepository
    {
        public OrdenTrabajoRepository()
        {
            ConnectionFactoryAvis myConection = new ConnectionFactoryAvis();
            _cnx = myConection.GetConnection;
        }

        public OrdenTrabajo Get(int pintIdCliente, string pstrPatente)
        {
            Error myError = new Error();
            try
            {
                var query = "Drilo_OrdenTrabajo_Select";
                DynamicParameters p = new DynamicParameters();
                p.Add(name: "@IdCliente", value: pintIdCliente, dbType: DbType.Int32);
                p.Add(name: "@Patente", value: pstrPatente, dbType: DbType.String);
                p.Add(name: "@DescError", dbType: DbType.String, direction: ParameterDirection.Output, size: 1000);
                p.Add(name: "@NumError", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                IEnumerable<OrdenTrabajo> list = _cnx.Query<OrdenTrabajo>(sql: query, param: p, commandType: CommandType.StoredProcedure);
                myError.ErrorCode = p.Get<int>(name: "@NumError");
                myError.ErrorMessage = p.Get<string>(name: "@DescError");
                return myError.ErrorCode > 0 ? throw new CustomException(message: myError.ErrorMessage, localError: myError) : list.First();
            }
            catch (Exception e)
            {
                throw new Exception(message: $"Error obteniendo Orden de trabajo: {e.Message}");
            }
        }

        public IEnumerable<OrdenTrabajo> GetListaOrdenesTrabajo(int pintIdCliente, string pstrPatente)
        {
            Error myError = new Error();
            try
            {
                var query = "Drilo_OrdenTrabajo_Select";
                DynamicParameters p = new DynamicParameters();
                p.Add(name: "@IdCliente", value: pintIdCliente, dbType: DbType.Int32);
                p.Add(name: "@Patente", value: pstrPatente, dbType: DbType.String);
                p.Add(name: "@DescError", dbType: DbType.String, direction: ParameterDirection.Output, size: 1000);
                p.Add(name: "@NumError", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                IEnumerable<OrdenTrabajo> list = _cnx.Query<OrdenTrabajo>(sql: query, param: p, commandType: CommandType.StoredProcedure);
                myError.ErrorCode = p.Get<int>(name: "@NumError");
                myError.ErrorMessage = p.Get<string>(name: "@DescError");
                return myError.ErrorCode > 0 ? throw new CustomException(message: myError.ErrorMessage, localError: myError) : list;
            }
            catch (Exception e)
            {
                throw new Exception(message: $"Error obteniendo listado de Ordenes de trabajo: {e.Message}");
            }
        }
    }
}
