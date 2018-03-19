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
                var query = "Drilo_Cliente_Select_GetEmpresa";
                DynamicParameters p = new DynamicParameters();
                p.Add(name: "@ClienteRut", value: pstrRut, dbType: DbType.String);
                p.Add(name: "@NumeroCliente", value: pintNumeroCliente);
                IEnumerable<Empresa> list = _cnx.Query<Empresa>(sql: query,param: p, commandType: CommandType.StoredProcedure);
                return list.First();
            }
            catch (Exception e)
            {
                throw new Exception(message: "Error obteniendo Empresa: " + e.Message);
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
                var query = "Drilo_Cliente_PUTEmpresa";
                DynamicParameters p = new DynamicParameters();
                p.Add(name: "@clienteNumero", value: entity.clienteNumero);
                p.Add(name: "@clienteRut", value: entity.clienteRut);
                p.Add(name: "@ciudadCodigo", value: entity.ciudadCodigo);
                p.Add(name: "@clienteNomRazonSocial", value: entity.clienteNomRazonSocial);
                p.Add(name: "@clienteGiro", value: entity.clienteGiro);
                p.Add(name: "@clienteDirComercial", value: entity.clienteDirComercial);
                p.Add(name: "@clienteCodPostal", value: entity.clienteCodPostal);
                p.Add(name: "@clienteTelefono", value: entity.clienteNumero);
                p.Add(name: "@clienteMail", value: entity.clienteMail);
                p.Add(name: "@clienteWww", value: entity.clienteWww);
                p.Add(name: "@comunaCodigo", value: entity.comunaCodigo);
                p.Add(name: "@clienteRepresentante", value: entity.clienteRepresentante);
                p.Add(name: "@DescError", dbType: DbType.String, direction: ParameterDirection.Output, size: 1000);
                p.Add(name: "@NumError", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                numeroContacto = _cnx.Execute(sql: query, param: p, commandType: CommandType.StoredProcedure);
                myError.ErrorCode = p.Get<int>(name: "@NumError");
                myError.ErrorMessage = p.Get<string>(name: "@DescError");
                return myError.ErrorCode > 0 ? throw new CustomException(message: myError.ErrorMessage, localError: myError) : numeroContacto;
            }
            catch (Exception e)
            {
                throw new Exception(message: "Error actualizando  Empresa: " + e.Message);
            }
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
} 