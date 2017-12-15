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

        public IEnumerable<Contrato> GetListaContrato(int pintCodEmpresa, int pintClienteNumero)
        {
            try
            {
                var query = "ContratoLO_Select_GetContratos";
                DynamicParameters p = new DynamicParameters();
                p.Add("@CodEmpresa", pintCodEmpresa);
                p.Add("@ClienteNumero", pintClienteNumero);
                var listaContratos = _cnx.Query<Contrato>(query, p, commandType: CommandType.StoredProcedure);
                return listaContratos;
            }
            catch (Exception e)
            {
                throw new Exception("Error obteniendo listado Contratos: " + e.Message);
            }
        }

        public IEnumerable<Contrato> GetListaContrato(object pintCodEmpresa, object pintClienteNumero)
        {
            throw new NotImplementedException();
        }
    }
}
