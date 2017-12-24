using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using WebAPI.DataAccess.Infrastructure;
using WebAPI.Model;
using WebAPI.SQL;

namespace WebAPI.Repository
{
    public class EjecutivoRepository : GenericRepository<Ejecutivo>, IEjecutivoRepository
    {
        public EjecutivoRepository()
        {
            ConnectionFactoryAvis myConection = new ConnectionFactoryAvis();
            _cnx = myConection.GetConnection;
        }

        public IEnumerable<Ejecutivo> GetListaEjecutivos()
        {
            try
            {
                var query = Consultas.SqlText.STCEjecutivos_Select_GetEjecutivos;
                var list = _cnx.Query<Ejecutivo>(sql: query);
                return list;
            }
            catch (Exception e)
            {
                throw new Exception(message: "Error obteniendo Listado de Ejecutivos: " + e.Message);
            }
        }
    }
}
