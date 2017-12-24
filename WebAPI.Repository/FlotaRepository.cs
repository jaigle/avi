using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using WebAPI.DataAccess.Infrastructure;
using WebAPI.Model;
using WebAPI.SQL;

namespace WebAPI.Repository
{
    public class FlotaRepository : GenericRepository<Flota>, IFlotaRepository
    {
        public FlotaRepository()
        {
            ConnectionFactoryAvis myConection = new ConnectionFactoryAvis();
            _cnx = myConection.GetConnection;
        }

        public IEnumerable<Flota> GetListaFlota(int pintContrato, int pintGrupoVehiculo, int pintCliente)
        {
            Error myError = new Error();
            try
            {
                var query = "ContratoLO_Vehiculos_Select";
                DynamicParameters p = new DynamicParameters();
                p.Add(name: "@IdCliente", value: pintCliente, dbType: DbType.String);
                p.Add(name: "@IdContrato", value: pintContrato, dbType: DbType.String);
                p.Add(name: "@IdGrupoVehiculo", value: pintGrupoVehiculo, dbType: DbType.String);
                p.Add(name: "@DescError", dbType: DbType.String, direction: ParameterDirection.Output, size: 1000);
                p.Add(name: "@NumError", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                IEnumerable<Flota> list = _cnx.Query<Flota>(sql: query, param: p, commandType: CommandType.StoredProcedure);
                myError.ErrorCode = p.Get<int>(name: "@NumError");
                myError.ErrorMessage = p.Get<string>(name: "@DescError");
                return myError.ErrorCode > 0 ? throw new CustomException(message: myError.ErrorMessage, localError: myError) : list;
            }
            catch (Exception e)
            {
                throw new Exception(message: "Error obteniendo listado de Flota por Contacto o por grupo de vehiculo: " + e.Message);
            }
        }
    }
}
