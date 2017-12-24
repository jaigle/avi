using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using WebAPI.DataAccess.Infrastructure;
using WebAPI.Model;

namespace WebAPI.Repository
{
    public class ContratoRepository : GenericRepository<Contrato>, IContratoRepository
    {
        public ContratoRepository()
        {
            ConnectionFactoryAvis myConection = new ConnectionFactoryAvis();
            _cnx = myConection.GetConnection;
        }

        public IEnumerable<Contrato> GetListaContrato(int pintCodEmpresa)
        {
            try
            {
                var query = "ContratoLO_Select_GetContratos";
                DynamicParameters p = new DynamicParameters();
                p.Add(name: "@CodEmpresa", value: pintCodEmpresa);
                var listaContratos = _cnx.Query<Contrato>(sql: query, param: p, commandType: CommandType.StoredProcedure);
                return listaContratos;
            }
            catch (Exception e)
            {
                throw new Exception(message: "Error obteniendo listado Contratos: " + e.Message);
            }
        }
    }
}
