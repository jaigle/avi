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
                var query = "Drilo_ContratoLO_Select_GetContratos";
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

        public IEnumerable<ContratoAnexo> GetListaContratoAnexo(int pintCliente)
        {
            Error myError = new Error();
            try
            {
                var query = "Drilo_ContratoyAnexo_Select";
                DynamicParameters p = new DynamicParameters();
                p.Add(name: "@Cliente_Numero", value: pintCliente, dbType: DbType.Int64);
                p.Add(name: "@DescError", dbType: DbType.String, direction: ParameterDirection.Output, size: 1000);
                p.Add(name: "@NumError", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                IEnumerable<ContratoAnexo> list = _cnx.Query<ContratoAnexo>(sql: query, param: p, commandType: CommandType.StoredProcedure);
                myError.ErrorCode = p.Get<int>(name: "@NumError");
                myError.ErrorMessage = p.Get<string>(name: "@DescError");
                return myError.ErrorCode > 0 ? throw new CustomException(message: myError.ErrorMessage, localError: myError) : list;
            }
            catch (Exception e)
            {
                throw new Exception(message: "Error obteniendo listado ContratosAnexos: " + e.Message);
            }



            //try
            //{
            //    var query = "Drilo_ContratoyAnexo_Select";
            //    DynamicParameters p = new DynamicParameters();
            //    p.Add(name: "@Cliente_Numero", value: pintCliente);
            //    var listaContratos = _cnx.Query<ContratoAnexo>(sql: query, param: p, commandType: CommandType.StoredProcedure);
            //    return listaContratos;
            //}
            //catch (Exception e)
            //{
            //    throw new Exception(message: "Error obteniendo listado ContratosAnexos: " + e.Message);
            //}
        }
    }
}
