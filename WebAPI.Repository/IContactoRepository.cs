using System.Collections.Generic;
using WebAPI.Model;

namespace WebAPI.Repository
{
    public interface IContactoRepository : IGenericRepository<ContactoDto>
    {
        IEnumerable<ContactoDto> GetListaComunas();
    }
}
