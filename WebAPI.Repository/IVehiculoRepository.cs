using System.Collections.Generic;
using WebAPI.Model;

namespace WebAPI.Repository
{
    public interface IVehiculoRepository : IGenericRepository<Vehiculo>
    {
        IEnumerable<Vehiculo> GetListaVehiculos();
    }
}
