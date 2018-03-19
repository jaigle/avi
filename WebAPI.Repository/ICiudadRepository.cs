using System.Collections.Generic;
using WebAPI.Model;

namespace WebAPI.Repository
{
    public interface ICiudadRepository : IGenericRepository<Ciudad>
    {
        IEnumerable<Ciudad> GetListaCiudades();
    }
}
