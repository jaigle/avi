using System;
using System.Collections.Generic;
using Dapper;
using WebAPI.DataAccess.Infrastructure;
using WebAPI.Model;
using WebAPI.SQL;

namespace WebAPI.Repository
{
    public class CiudadRepository : GenericRepository<Ciudad>, ICiudadRepository
    {
        public CiudadRepository()
        {
            ConnectionFactoryAvis myConection = new ConnectionFactoryAvis();
            _cnx = myConection.GetConnection;
        }

        public IEnumerable<Ciudad> GetListaCiudades()
        {
            try
            {
                var query = Consultas.SqlText.Ciudad_Select;
                var list = _cnx.Query<Ciudad>(sql: query);
                return list;
            }
            catch (Exception e)
            {
                throw new Exception(message: "Error obteniendo Listado de Ciudaddes: " + e.Message);
            }
        }
    }
}
