using System;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using Dapper;
using WebAPI.DataAccess.Infrastructure;
using WebAPI.Model;
using WebAPI.SQL;

namespace WebAPI.Repository
{
    public class MantencionRepository : GenericRepository<Mantencion>, IMantencionRepository
    {
        public MantencionRepository()
        {
            ConnectionFactoryAvis myConection = new ConnectionFactoryAvis();
            _cnx = myConection.GetConnection;
        }

        public IEnumerable<Mantencion> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Mantencion> FindBy(Expression<Func<Mantencion, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public int Add(Mantencion entity)
        {
            int valor = 0;
            try
            {
                var query = "Drilo_AgendaMant_Ins_POSTMantenimiento";
                valor = _cnx.ExecuteScalar<int>(sql: query, param: new
                {
                    IdEstadoAgenda = 1,
                    PendConf = "Avis",
                    IdTaller = entity.idTaller,
                    IdDiaSemana = 0,
                    IdHorario = entity.idHorario,
                    FechaAgenda = entity.Fecha,
                    Patente = entity.Patente,
                    KilomIndicadoCliente = entity.kilomIndicadoCliente,
                    ClienteSolReemplazo = entity.ClienteSolReemplazo,
                    IdServicio = entity.IdServicio,
                    ObsServicio = entity.ObsServicio,
                    NumCliente = entity.NumCliente,
                    IdMedioAgenda = 4,
                    IdContacto = entity.idContacto,
                    Kilom_Veh = entity.kilomVeh,
                    token = entity.token,
                    esMantencion = entity.esMantencion,
                    esSiniestro = entity.esSiniestro,
                    esReparacion = entity.esReparacion
                }, commandType: CommandType.StoredProcedure);
            }
            catch (Exception e)
            {
                throw new Exception(message: "Error insertando Mantencion: " + e.Message);
            }
            return valor;
        }

        public Mantencion Delete(Mantencion entity)
        {
            throw new NotImplementedException();
        }

        public int Edit(Mantencion entity)
        {
            int valor = 0;
            try
            {
                var query = "Drilo_AgendaMant_Upd_PUTMantenimiento";
                valor = _cnx.ExecuteScalar<int>(sql: query, param: new
                {
                    IdEstadoAgenda = entity.idEstadoAgenda,
                    IdAgenda = entity.Id,
                    token = entity.token
                },commandType: CommandType.StoredProcedure);
            }
            catch (Exception e)
            {
                throw new Exception(message: "Error actualizando registro: " + e.Message);
            }
            return valor;
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MantencionDto> GetListaMantencion(int pintIdAgenda, int pintNumCliente)
        {
            IEnumerable<MantencionDto> valor;
            try
            {
                var query = "Drilo_AgendaMant_Select_GetListMantencion";
                valor = _cnx.Query<MantencionDto>(sql: query, param: new
                {
                    IdAgenda = pintIdAgenda,
                    NumCliente = pintNumCliente
                }, commandType: CommandType.StoredProcedure);
            }
            catch (Exception e)
            {
                throw new Exception(message: "Error seleccionando de Mantencion: registro: " + e.Message);
            }
            return valor;
        }

        public IEnumerable<Disponibilidad> GetDisponibilidad(int pintIdTaller, DateTime pFecha)
        {
            //Error myError = new Error();
            //Disponibilidad entity = new Disponibilidad();
            //int valor;
            //try
            //{
            //    var query = "Drilo_AgendaMant_Validacion";
            //    DynamicParameters p = new DynamicParameters();
            //    //p.Add(name: "@Mensaje", dbType: DbType.String, direction: ParameterDirection.Output, size: 1000);
            //    //p.Add(name: "@IdTaller", value: pintIdTaller);
            //    //p.Add(name: "@FechaAgenda", dbType: DbType.DateTime, value: pFecha);
            //    p.Add(name: "@Mensaje", dbType: DbType.String, direction: ParameterDirection.Output, size: 1000);
            //    p.Add(name: "@NumError", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
            //    _cnx.Query(sql: query, param: p, commandType: CommandType.StoredProcedure);
            //   // _cnx.ExecuteScalar<int>(sql: query, commandType: CommandType.StoredProcedure);
            //    myError.ErrorCode = p.Get<int>(name: "@NumError");
            //    myError.ErrorMessage = p.Get<string>(name: "@Mensaje");
            //    entity.mensaje = myError.ErrorMessage;
            // }
            //catch (Exception e)
            //{
            //    throw new Exception(message: $"Error seleccionando la Disponibilidad: {e.Message}");
            //}
            //return myError.ErrorCode > 0 ? throw new CustomException(message: myError.ErrorMessage, localError: myError) : entity;

            Error myError = new Error();
            try
            {
                var query = "Drilo_Mantenimiento_GetDisponibilidad";
                DynamicParameters p = new DynamicParameters();
                p.Add(name: "@IdTaller", value: pintIdTaller, dbType: DbType.String);
                p.Add(name: "@FechaAgenda", value: pFecha, dbType: DbType.DateTime);
                p.Add(name: "@DescError", dbType: DbType.String, direction: ParameterDirection.Output, size: 1000);
                p.Add(name: "@NumError", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
                IEnumerable<Disponibilidad> list = _cnx.Query<Disponibilidad>(sql: query, param: p, commandType: CommandType.StoredProcedure);
                myError.ErrorCode = p.Get<int>(name: "@NumError");
                myError.ErrorMessage = p.Get<string>(name: "@DescError");
                return myError.ErrorCode > 0 ? throw new CustomException(message: myError.ErrorMessage, localError: myError) : list;
            }
            catch (Exception e)
            {
                throw new Exception(message: "Error obteniendo Disponibilidad: " + e.Message);
            }
        }
    }
}
