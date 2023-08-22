using PrubeIngresoLogistica.Core.Entities;

namespace PrubeIngresoLogistica.Core.Interfaces.Repositories
{
    public interface ILugarDestinoRepository
    {
        Task Add(LugarDestino lugarDestino);
        Task<LugarDestino> GetById(int id);
    }
}
