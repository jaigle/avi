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

        public IEnumerable<Flota> GetListaFlota(int pintContrato, int pintGrupoVehiculo)
        {
            Error myError = new Error();
            try
            {
                var query = "ContratoLO_Vehiculos_Select";
                DynamicParameters p = new DynamicParameters();
                p.Add("@IdContrato", pintContrato, DbType.String);
                p.Add("@IdGrupoVehiculo", pintGrupoVehiculo, DbType.String);
                p.Add("@DescError", dbType: DbType.String, direction: ParameterDirection.Output, size: 1000);
                p.Add("@NumError", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                IEnumerable<Flota> list = _cnx.Query<Flota>(query, p, commandType: CommandType.StoredProcedure);
                myError.ErrorCode = p.Get<int>("@NumError");
                myError.ErrorMessage = p.Get<string>("@DescError");
                return myError.ErrorCode > 0 ? throw new CustomException(myError.ErrorMessage, myError) : list;
            }
            catch (Exception e)
            {
                throw new Exception("Error obteniendo listado de Flota por Contacto o por grupo de vehiculo: " + e.Message);
            }
        }
    }
}
