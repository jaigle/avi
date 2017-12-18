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
                var query = "ContratoLO_GrupoDF_Select";
                DynamicParameters p = new DynamicParameters();
                p.Add("@IdContrato", pintContrato, DbType.String);
                p.Add("@DescError", dbType: DbType.String, direction: ParameterDirection.Output, size: 1000);
                p.Add("@NumError", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                IEnumerable<Anexo> list = _cnx.Query<Anexo>(query, p, commandType: CommandType.StoredProcedure);
                myError.ErrorCode = p.Get<int>("@NumError");
                myError.ErrorMessage = p.Get<string>("@DescError");
                return myError.ErrorCode > 0 ? throw new CustomException(myError.ErrorMessage, myError) : list.First();
            }
            catch (Exception e)
            {
                throw new Exception("Error obteniendo Anexo: " + e.Message);
            }
        }
    }
}
