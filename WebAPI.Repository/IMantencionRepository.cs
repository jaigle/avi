using System.Collections.Generic;
using WebAPI.Model;

namespace WebAPI.Repository
{
    public interface IMantencionRepository : IGenericRepository<Mantencion>
    {
        IEnumerable<Mantencion> GetListaMantencion();
    }
}
