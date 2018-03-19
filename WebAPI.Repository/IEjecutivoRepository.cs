using System.Collections.Generic;
using WebAPI.Model;

namespace WebAPI.Repository
{
    public interface IEjecutivoRepository : IGenericRepository<Ejecutivo>
    {
        IEnumerable<Ejecutivo> GetListaEjecutivos();
    }
}
