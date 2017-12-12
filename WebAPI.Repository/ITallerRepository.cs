using System.Collections.Generic;
using WebAPI.Model;

namespace WebAPI.Repository
{
    public interface ITallerRepository : IGenericRepository<Taller>
    {
        IEnumerable<Taller> GetListaTalleres();
    }
}
