using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Dapper;
using WebAPI.DataAccess.Infrastructure;
using WebAPI.Model;
using WebAPI.SQL;

namespace WebAPI.Repository
{
    public class VehiculoRepository : GenericRepository<Vehiculo>, IVehiculoRepository
    {
        public VehiculoRepository()
        {
            ConnectionFactoryAvis myConection = new ConnectionFactoryAvis();
            _cnx = myConection.GetConnection;
        }

        public IEnumerable<Vehiculo> GetListaVehiculos()
        {
            try
            {
                var query = Consultas.SqlText.Comuna_Select;
                var list = _cnx.Query<Vehiculo>(sql: query);
                return list;
            }
            catch (Exception e)
            {
                throw new Exception(message: $"Error obteniendo Listado de Vehiculos: {e.Message}");
            }
        }

        public Vehiculo GetVehiculo(string pstrPatente)
        {
            Error myError = new Error();
            try
            {
                var query = "[Drilo_Flota_Select_GetVehiculo]";
                DynamicParameters p = new DynamicParameters();
                p.Add(name: "@Patente", value: pstrPatente, dbType: DbType.String);
                p.Add(name: "@DescError", dbType: DbType.String, direction: ParameterDirection.Output, size: 1000);
                p.Add(name: "@NumError", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                IEnumerable<Vehiculo> list = _cnx.Query<Vehiculo>(sql: query, param: p, commandType: CommandType.StoredProcedure);
                myError.ErrorCode = p.Get<int>(name: "@NumError");
                myError.ErrorMessage = p.Get<string>(name: "@DescError");
                return myError.ErrorCode > 0 ? throw new CustomException(message: myError.ErrorMessage, localError: myError) : list.First();
            }
            catch (Exception e)
            {
                throw new Exception(message: "Error obteniendo Vehiculo: " + e.Message);
            }
        }
    }
}
