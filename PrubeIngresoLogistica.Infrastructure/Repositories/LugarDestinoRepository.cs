using PrubeIngresoLogistica.Core.Entities;
using PrubeIngresoLogistica.Core.Interfaces.Repositories;
using PrubeIngresoLogistica.Infrastructure.Data;

namespace PrubeIngresoLogistica.Infrastructure.Repositories
{
    public class LugarDestinoRepository : ILugarDestinoRepository
    {
        private readonly PersistenceContext _persistenceContext;

        public LugarDestinoRepository(PersistenceContext persistenceContext)
        {
            _persistenceContext = persistenceContext;
        }

        public async Task Add(LugarDestino lugarDestino)
        {
            await _persistenceContext.AddAsync(lugarDestino);
        }

        public async Task<LugarDestino> GetById(int id)
        {
            return await _persistenceContext.LugaresDestinos.FindAsync(id);
        }
    }
}
