using PrubeIngresoLogistica.Core.DTOs;
using PrubeIngresoLogistica.Core.Entities;

namespace PrubeIngresoLogistica.Core.Interfaces.Repositories
{
    public interface IEntregaRepository
    {
        Task<Entrega> GetById(int id);
        Task Add(Entrega entrega);
        Task Update(Entrega entrega);
        Task Delete(int id);
         Task<bool> GetByNumeroGuia(string numeroGuia);
         Task<IEnumerable<Entrega>> Filter(FiltroReqDTO filtro);

    }
}
