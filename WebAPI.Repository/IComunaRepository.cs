using System.Collections.Generic;
using WebAPI.Model;

namespace WebAPI.Repository
{
    public interface IComunaRepository : IGenericRepository<Comuna>
    {
        IEnumerable<Comuna> GetListaComunas();
    }
}
