﻿using System;
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
    public class ContactoRepository : GenericRepository<ContactoDto>
    {
        public ContactoRepository()
        {
            ConnectionFactoryAvis myConection = new ConnectionFactoryAvis();
            _cnx = myConection.GetConnection;
        }

        public IEnumerable<ContactoDto> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ContactoDto> FindBy(Expression<Func<ContactoDto, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public int Add(ContactoDto entity)
        {
            Error myError = new Error();
            int numeroContacto;

            try
            {                
                var query = "ContactoNew_Ins_POSTContacto";
                DynamicParameters p = new DynamicParameters();
                p.Add(name: "@Rut", value: entity.contacRutContacto);
                p.Add(name: "@Nombre", value: entity.contacNombre);
                p.Add(name: "@Contac_Numero", value: entity.contacNumero);
                p.Add(name: "@CodigoTipoNegocio", value: entity.codigoTipoNegocio);
                p.Add(name: "@idTipoContacto", value: entity.idTipoContacto);
                p.Add(name: "@Contac_Telefono1", value: entity.telefono1);
                p.Add(name: "@Contac_Mail", value: entity.contacMail);
                p.Add(name: "@Contac_Celular", value: entity.contacCelular); 
                p.Add(name: "@Ciudad_Codigo", value: entity.ciudadCodigo);
                p.Add(name: "@Cliente_Numero", value: entity.clienteNumero);
                p.Add(name: "@DescError", dbType: DbType.String, direction: ParameterDirection.Output, size: 1000);
                p.Add(name: "@NumError", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                numeroContacto = _cnx.Execute(sql: query, param: p, commandType: CommandType.StoredProcedure);
                myError.ErrorCode = p.Get<int>(name: "@NumError");
                myError.ErrorMessage = p.Get<string>(name: "@DescError");
                return myError.ErrorCode > 0 ? throw new CustomException(message: myError.ErrorMessage, localError: myError) : numeroContacto;
            }
            catch (Exception e)
            {
                throw new Exception(message: "Error adicionado ContactNew : " + e.Message);
            }
        }

        public ContactoDto Delete(ContactoDto entity)
        {
            throw new NotImplementedException();
        }

        public void Edit(ContactoDto entity)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }


        public IEnumerable<TipoContacto> GetListaTipoContacto()
        {
            try
            {
                var query = Consultas.SqlText.TipoContacto_Select;
                IEnumerable<TipoContacto> entity = _cnx.Query<TipoContacto>(sql: query);
                return entity;
            }
            catch (Exception e)
            {
                throw new Exception(message: "Error obteniendo Listado de Tipos de Contactos: " + e.Message);
            }
        }

        /// <summary>
        /// Busqueda de ContactoNew que respondan a un rut especifico
        /// </summary>
        /// <param name="valueContacRutContacto">Rut pasado como parametro</param>
        /// <returns></returns>
        public ContactoNew GetContactoNewByRut(string valueContacRutContacto)
        {
            try
            {
                var query = Consultas.SqlText.ContactoNew_SelectPorRut;
                ContactoNew entity = _cnx.QuerySingle<ContactoNew>(sql: query, param: new { Rut = new DbString { Value = valueContacRutContacto, IsFixedLength = false, Length = 11, IsAnsi = true } });
                return entity;
            }
            catch (Exception e)
            {
                throw new Exception(message: "Error obteniendo ContactNew por Rut: " + e.Message);
            }
        }

        /// <summary>
        /// Obtiene un Contactocliente segun sus datos llave
        /// </summary>
        /// <param name="pintContactNumero">Parametro ContactNumero</param>
        /// <param name="pintClienteNumero">PArametro ClienteNumero</param>
        /// <returns></returns>
        public ContactoCliente GetContactoClienteByKey(int pintContactNumero, int pintClienteNumero)
        {
            try
            {
                var query = Consultas.SqlText.ContactoCliente_Insert;
                ContactoCliente entity = _cnx.QuerySingle<ContactoCliente>(sql: query, param: new
                {
                    ContactNumero = pintContactNumero,
                    ClienteNumero = pintClienteNumero
                });
                return entity;
            }
            catch (Exception e)
            {
                throw new Exception(message: "Error obteniendo ContactCliente por su llave: " + e.Message);
            }
        }

        /// <summary>
        /// Obtiene el maximos del valor del campo + 1
        /// </summary>
        /// <returns></returns>
        private int GetContactoNew_NuevoContactNumero()
        {
            try
            {
                var query = Consultas.SqlText.ContactNew_Max;
                var numero = _cnx.Query<int>(sql: query).First();
                return numero;
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        private ContactoNew GetContactoNew_ByContactoNumber(int pintContactNumber)
        {
            try
            {
                var query = Consultas.SqlText.ContactoNew_SelectPorContactNumber;
                var entity = _cnx.QuerySingle<ContactoNew>(sql: query, param: new
                {
                    Numero = pintContactNumber
                });
                return entity;
            }
            catch (Exception e)
            {
                throw new Exception(message: "Error obteiendo ContactNew por Contac_Numero: " + e.Message);
            }
        }

        /// <summary>
        /// Obtiene listado de contactos por Empresa
        /// </summary>
        /// <param name="pintIdEmpresa">Empresa para saber sus contactos, en casode que sea 0 no lo tiene en cuenta</param>
        /// <returns></returns>
        public IEnumerable<ContactoEmpresa> GetContactoPorEmpresa(int pintIdEmpresa)
        {
            try
            {
                var query = Consultas.SqlText.Contactos_SelectPorEmpresa;
                IEnumerable<ContactoEmpresa> entity = _cnx.Query<ContactoEmpresa>(sql: query, param: new
                {
                    IdEmpresa = pintIdEmpresa
                }).ToList();
                return entity;
            }
            catch (Exception e)
            {
                throw new Exception(message: "Error obteniendo Contactos por Empresa: " + e.Message);
            }
        }

        /// <summary>
        /// Actualiza un registro de Contacto de Clientes
        /// </summary>
        /// <param name="entity"></param>
        public void PutContactoCliente(ContactoCliente entity)
        {
            try
            {
                var query = Consultas.SqlText.ContactoCliente_Update;
                _cnx.Execute(sql: query, param: new
                {
                    TipoContrato = entity.idTipoContacto,
                    Telefono1 = entity.telefono1,
                    Celular = entity.contacCelular,
                    Mail = entity.contacMail,
                    Ciudad = entity.ciudadCodigo,
                    ContactNumero = entity.contactoNumero,
                    ClienteNumero = entity.clienteNumero
                });
            }
            catch (Exception e)
            {
                throw new Exception(message: "Error actualizando ContactosClientes: " + e.Message);
            }
        }


        public void DeleteContactoCliente(int pintContactNumero, int pintClienteNumero)
        {
            try
            {
                var query = Consultas.SqlText.ContactoCliente_Delete;
                _cnx.Execute(sql: query, param: new
                {
                    ContactNumero = pintContactNumero,
                    ClienteNumero = pintClienteNumero
                });
            }
            catch (Exception e)
            {
                throw new Exception(message: "Error desactivando ContactosClientes: " + e.Message);
            }
        }



    }
}
