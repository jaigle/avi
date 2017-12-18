using System.Collections.Generic;
using WebAPI.Model;

namespace WebAPI.Repository
{
    public interface IFlotaRepository : IGenericRepository<Flota>
    {
        IEnumerable<Flota> GetListaFlota(int p1,int p2);
    }
}
