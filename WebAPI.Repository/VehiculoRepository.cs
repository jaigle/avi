using System;
using System.Collections.Generic;
using System.Linq;
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
            try
            {
                var query = Consultas.SqlText.FLota_Select;
                Vehiculo entity = _cnx.QuerySingle<Vehiculo>(sql: query, param: new
                {
                    Patente = pstrPatente
                });
                return entity;
            }
            catch (Exception e)
            {
                throw new Exception(message: "Error obteniendo Vehiculo: " + e.Message);
            }
        }
    }
}
