using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using Dapper;
using WebAPI.DataAccess.Infrastructure;
using WebAPI.Model;
using WebAPI.SQL;

namespace WebAPI.Repository
{
    public class SiniestroRepository : GenericRepository<Siniestro>
    {
        public SiniestroRepository()
        {
            ConnectionFactoryAvis myConection = new ConnectionFactoryAvis();
            _cnx = myConection.GetConnection;
        }

        public IEnumerable<Siniestro> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ContactoDto> FindBy(Expression<Func<ContactoDto, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public int Add(Siniestro entity)
        {
            Error myError = new Error();            
        int numeroContacto;

            try
            {                
                //var query = "Drilo_ContactoNew_Ins_POSTContacto";
                //DynamicParameters p = new DynamicParameters();
                //p.Add(name: "@Rut", value: entity.contacRutContacto);
                //p.Add(name: "@Nombre", value: entity.contacNombre);
                //p.Add(name: "@Contac_Numero", value: entity.contacNumero, direction: ParameterDirection.Output);
                //p.Add(name: "@CodigoTipoNegocio", value: entity.codigoTipoNegocio);
                //p.Add(name: "@idTipoContacto", value: entity.idTipoContacto);
                //p.Add(name: "@Contac_Telefono1", value: entity.telefono1);
                //p.Add(name: "@Contac_Mail", value: entity.contacMail);
                //p.Add(name: "@Contac_Celular", value: entity.contacCelular); 
                //p.Add(name: "@Ciudad_Codigo", value: entity.ciudadCodigo);
                //p.Add(name: "@Cliente_Numero", value: entity.clienteNumero);
                //p.Add(name: "@DescError", dbType: DbType.String, direction: ParameterDirection.Output, size: 1000);
                //p.Add(name: "@NumError", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                //_cnx.Execute(sql: query, param: p, commandType: CommandType.StoredProcedure);
                //myError.ErrorCode = p.Get<int>(name: "@NumError");
                //myError.ErrorMessage = p.Get<string>(name: "@DescError");
                //numeroContacto = p.Get<int>(name: "@Contac_Numero");
                //return myError.ErrorCode > 0 ? throw new CustomException(message: myError.ErrorMessage, localError: myError) : numeroContacto;
            }
            catch (Exception e)
            {
                throw new Exception(message: "Error adicionado ContactNew : " + e.Message);
            }
        }      

    }
}
