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

        public int Add(Siniestro entity)
        {
            Error myError = new Error();
            try
            {
                var query = "Siniestro_Ins_POSTSiniestro";
                DynamicParameters p = new DynamicParameters();
                p.Add(name: "@id", value: entity.id);
                p.Add(name: "@idEmpresa", value: entity.idEmpresa);
                p.Add(name: "@patente", value: entity.patente);
                p.Add(name: "@email", value: entity.email);
                p.Add(name: "@denuncianteNombre", value: entity.denuncianteNombre);
                p.Add(name: "@denuncianteRut", value: entity.denuncianteRut);
                p.Add(name: "@denuncianteNacionalidad", value: entity.denuncianteNacionalidad);
                p.Add(name: "@denuncianteDomicilio", value: entity.denuncianteDomicilio);
                p.Add(name: "@denuncianteComuna", value: entity.denuncianteComuna);
                p.Add(name: "@denuncianteCiudad", value: entity.denuncianteCiudad);
                p.Add(name: "@siniestroFecha", value: entity.siniestroFecha);
                p.Add(name: "@siniestroHora", value: entity.siniestroHora);
                p.Add(name: "@siniestroDireccion", value: entity.siniestroDireccion);
                p.Add(name: "@siniestroCiudad", value: entity.siniestroCiudad);
                p.Add(name: "@siniestroComuna", value: entity.siniestroComuna);
                p.Add(name: "@siniestroTipo", value: entity.siniestroTipo);
                p.Add(name: "@siniestroTipoOtro", value: entity.siniestroTipoOtro);
                p.Add(name: "@siniestroAccion", value: entity.siniestroAccion);
                p.Add(name: "@siniestroRelato", dbType: DbType.String, value: entity.siniestroRelato);
                p.Add(name: "@siniestroDano", value: entity.siniestroDano);
                p.Add(name: "@siniestroGrua", value: entity.siniestroGrua);
                p.Add(name: "@siniestroExpediente", value: entity.siniestroExpediente);
                p.Add(name: "@siniestroVelocidad", value: entity.siniestroVelocidad);
                p.Add(name: "@culpable", value: entity.culpable);
                p.Add(name: "@lesionados", value: entity.lesionados);
                p.Add(name: "@terceros", value: entity.terceros);
                p.Add(name: "@unidadPolicial", value: entity.unidadPolicial);
                p.Add(name: "@fechaAviso", value: entity.fechaAviso);
                p.Add(name: "@horaAviso", value: entity.horaAviso);
                p.Add(name: "@numParte", value: entity.numParte);
                p.Add(name: "@numFolio", value: entity.numFolio);
                p.Add(name: "@numConstancia", value: entity.numConstancia);
                p.Add(name: "@citacion", value: entity.citacion);
                p.Add(name: "@citacionFecha", value: entity.citacionFecha);
                p.Add(name: "@juzgado", value: entity.juzgado);
                p.Add(name: "@ciArchivo", value: entity.ciArchivo);
                p.Add(name: "@licenciaArchivo", value: entity.licenciaArchivo);
                p.Add(name: "@constanciaArchivo", value: entity.constanciaArchivo);
                p.Add(name: "@citacionArchivo", value: entity.citacionArchivo);
                p.Add(name: "@DescError", dbType: DbType.String, direction: ParameterDirection.Output, size: 1000);
                p.Add(name: "@NumError", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                _cnx.Execute(sql: query, param: p, commandType: CommandType.StoredProcedure);
                myError.ErrorCode = p.Get<int>(name: "@NumError");
                myError.ErrorMessage = p.Get<string>(name: "@DescError");
                return myError.ErrorCode > 0 ? throw new CustomException(message: myError.ErrorMessage, localError: myError) : entity.id;
            }
            catch (Exception e)
            {
                throw new Exception(message: "Error adicionado Siniestro : " + e.Message);
            }
        }

        public int AddFoto(SiniestroFoto entity)
        {
            Error myError = new Error();
            int numeroContacto;

            try
            {
                var query = "SiniestroFoto_Ins_POSTSiniestroFoto";
                DynamicParameters p = new DynamicParameters();
                p.Add(name: "@Id", value: entity.Id);
                p.Add(name: "@siniestroId", value: entity.siniestroId);
                p.Add(name: "@path", value: entity.path);
                p.Add(name: "@DescError", dbType: DbType.String, direction: ParameterDirection.Output, size: 1000);
                p.Add(name: "@NumError", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                _cnx.Execute(sql: query, param: p, commandType: CommandType.StoredProcedure);
                myError.ErrorCode = p.Get<int>(name: "@NumError");
                myError.ErrorMessage = p.Get<string>(name: "@DescError");
                return myError.ErrorCode > 0 ? throw new CustomException(message: myError.ErrorMessage, localError: myError) : entity.Id;
            }
            catch (Exception e)
            {
                throw new Exception(message: "Error adicionado Siniestro Foto : " + e.Message);
            }
        }

        public int AddTercero(SiniestroTercero entity)
        {
            Error myError = new Error();
            int numeroContacto;

            try
            {
                var query = "SiniestroTercero_Ins_POSTSiniestroTercero";
                DynamicParameters p = new DynamicParameters();
                p.Add(name: "@Id", value: entity.Id);
                p.Add(name: "@siniestroId", value: entity.siniestroId);
                p.Add(name: "@nombre", value: entity.nombre);
                p.Add(name: "@rut", value: entity.rut);
                p.Add(name: "@telefono", value: entity.telefono);
                p.Add(name: "@domicilio", value: entity.domicilio);
                p.Add(name: "@email", value: entity.email);
                p.Add(name: "@compania", value: entity.compania);
                p.Add(name: "@patente", value: entity.patente);
                p.Add(name: "@marcas", value: entity.marcas);
                p.Add(name: "@modelo", value: entity.modelo);
                p.Add(name: "@ano", value: entity.ano);
                p.Add(name: "@DescError", dbType: DbType.String, direction: ParameterDirection.Output, size: 1000);
                p.Add(name: "@NumError", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                _cnx.Execute(sql: query, param: p, commandType: CommandType.StoredProcedure);
                myError.ErrorCode = p.Get<int>(name: "@NumError");
                myError.ErrorMessage = p.Get<string>(name: "@DescError");
                return myError.ErrorCode > 0 ? throw new CustomException(message: myError.ErrorMessage, localError: myError) : entity.Id;
            }
            catch (Exception e)
            {
                throw new Exception(message: "Error adicionado Siniestro Tercero : " + e.Message);
            }
        }

    }
}
