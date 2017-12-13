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
                var query = "AgendaMant_Ins_POSTMantenimiento";
                valor = _cnx.ExecuteScalar<int>(query, new
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
                    Kilom_Veh = entity.kilomVeh
                }, commandType: CommandType.StoredProcedure);
            }
            catch (Exception e)
            {
                throw new Exception("Error insertando Mantencion: " + e.Message);
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
                var query = "[AgendaMant_Upd_PUTMantenimiento]";
                valor = _cnx.ExecuteScalar<int>(query, new
                {
                    IdEstadoAgenda = entity.idEstadoAgenda,
                    IdAgenda = entity.Id
                },commandType: CommandType.StoredProcedure);
            }
            catch (Exception e)
            {
                throw new Exception("Error actualizando registro: " + e.Message);
            }
            return valor;
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Mantencion> GetListaMantencion()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MantencionDto> GetListaMantencion(int pintIdAgenda, int pintNumCliente)
        {
            IEnumerable<MantencionDto> valor;
            try
            {
                var query = "AgendaMant_Select_GetListMantencion";
                valor = _cnx.Query<MantencionDto>(query, new
                {
                    IdAgenda = pintIdAgenda,
                    NumCliente = pintNumCliente
                }, commandType: CommandType.StoredProcedure);
            }
            catch (Exception e)
            {
                throw new Exception("Error seleccionando de Mantencion: registro: " + e.Message);
            }
            return valor;
        }

        public IEnumerable<MantencionDisponible> GetDisponibilidad(int pintIdTaller, DateTime pFecha)
        {
            Error myError = new Error();
            IEnumerable<MantencionDisponible> valor;
            try
            {

                var query = "AgendaMant_Validacion";
                DynamicParameters p = new DynamicParameters();
                p.Add("@Mensaje", "",DbType.String,ParameterDirection.Output);
                p.Add("@IdTaller", pintIdTaller);
                p.Add("@FechaAgenda", pFecha);
                p.Add("@NumError", dbType: DbType.Int16, direction: ParameterDirection.Output);
                valor = _cnx.Query<MantencionDisponible>(query, p, commandType: CommandType.StoredProcedure);
                myError.ErrorCode = p.Get<Int16>("@NumError");
                myError.ErrorMessage = p.Get<string>("@Mensaje");
            }
            catch (Exception e)
            {
                throw new CustomException("Error seleccionando de la Disponibilidad: registro: " + e.Message, myError);
            }
            return myError.ErrorCode > 0 ? throw new Exception(myError.ErrorMessage) : valor;
        }
    }
}
