using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using WebAPI.DataAccess.Infrastructure;
using WebAPI.Model;

namespace WebAPI.Repository
{
    public class AnexoRepository : GenericRepository<Anexo>, IAnexoRepository
    {
        public AnexoRepository()
        {
            ConnectionFactoryAvis myConection = new ConnectionFactoryAvis();
            _cnx = myConection.GetConnection;
        }

        public Anexo Get(int pintContrato)
        {
            Error myError = new Error();
            try
            {
                var query = "Drilo_ContratoLO_GrupoDF_Select";
                DynamicParameters p = new DynamicParameters();
                p.Add(name: "@IdContrato", value: pintContrato, dbType: DbType.String);
                p.Add(name: "@DescError", dbType: DbType.String, direction: ParameterDirection.Output, size: 1000);
                p.Add(name: "@NumError", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                IEnumerable<Anexo> list = _cnx.Query<Anexo>(sql: query, param: p, commandType: CommandType.StoredProcedure);
                myError.ErrorCode = p.Get<int>(name: "@NumError");
                myError.ErrorMessage = p.Get<string>(name: "@DescError");
                return myError.ErrorCode > 0 ? throw new CustomException(message: myError.ErrorMessage, localError: myError) : list.First();
            }
            catch (Exception e)
            {
                throw new Exception(message: "Error obteniendo Anexo: " + e.Message);
            }
        }
    }
}
