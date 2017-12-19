using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using Dapper;
using WebAPI.DataAccess.Infrastructure;
using WebAPI.Model;

namespace WebAPI.Repository
{
    public class EmpresaRepository : GenericRepository<Comuna>, IEmpresaRepository
    {
        public EmpresaRepository()
        {
            ConnectionFactoryAvis myConection = new ConnectionFactoryAvis();
            _cnx = myConection.GetConnection;
        }

        public Empresa Get(string pstrRut, int pintNumeroCliente)
        {
            try
            {
                var query = "Cliente_Select_GetEmpresa";
                DynamicParameters p = new DynamicParameters();
                p.Add("@ClienteRut", pstrRut, DbType.String);
                p.Add("@NumeroCliente", pintNumeroCliente);
                IEnumerable<Empresa> list = _cnx.Query<Empresa>(query,p, commandType: CommandType.StoredProcedure);
                return list.First();
            }
            catch (Exception e)
            {
                throw new Exception("Error obteniendo Empresa: " + e.Message);
            }
        }

        public IEnumerable<Empresa> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Empresa> FindBy(Expression<Func<Empresa, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Empresa Add(Empresa entity)
        {
            throw new NotImplementedException();
        }

        public Empresa Delete(Empresa entity)
        {
            throw new NotImplementedException();
        }

        public void Edit(Empresa entity)
        {
            throw new NotImplementedException();
        }

        public int Edit(Empresa_put entity)
        {
            Error myError = new Error();
            int numeroContacto;

            try
            {
                var query = "Cliente_PUTEmpresa";
                DynamicParameters p = new DynamicParameters();
                p.Add("@clienteNumero", entity.clienteNumero);
                p.Add("@clienteRut", entity.clienteRut);
                p.Add("@ciudadCodigo", entity.ciudadCodigo);
                p.Add("@clienteNomRazonSocial", entity.clienteNomRazonSocial);
                p.Add("@clienteGiro", entity.clienteGiro);
                p.Add("@clienteDirComercial", entity.clienteDirComercial);
                p.Add("@clienteCodPostal", entity.clienteCodPostal);
                p.Add("@clienteTelefono", entity.clienteNumero);
                p.Add("@clienteMail", entity.clienteMail);
                p.Add("@clienteWww", entity.clienteWww);
                p.Add("@comunaCodigo", entity.comunaCodigo);
                p.Add("@clienteRepresentante", entity.clienteRepresentante);
                p.Add("@DescError", dbType: DbType.String, direction: ParameterDirection.Output, size: 1000);
                p.Add("@NumError", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                numeroContacto = _cnx.Execute(query, p, commandType: CommandType.StoredProcedure);
                myError.ErrorCode = p.Get<int>("@NumError");
                myError.ErrorMessage = p.Get<string>("@DescError");
                return myError.ErrorCode > 0 ? throw new CustomException(myError.ErrorMessage, myError) : numeroContacto;
            }
            catch (Exception e)
            {
                throw new Exception("Error actualizando  Empresa: " + e.Message);
            }
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
} 