using System.Collections.Generic;
using WebAPI.Model;

namespace WebAPI.Repository
{
    public interface IContratoRepository : IGenericRepository<Contrato>
    {
        IEnumerable<Contrato> GetListaContrato(int pintCodEmpresa);
    }
}
