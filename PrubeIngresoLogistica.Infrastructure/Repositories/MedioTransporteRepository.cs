using PrubeIngresoLogistica.Core.Entities;
using PrubeIngresoLogistica.Core.Interfaces.Repositories;
using PrubeIngresoLogistica.Infrastructure.Data;

namespace PrubeIngresoLogistica.Infrastructure.Repositories
{
    public class MedioTransporteRepository : IMedioTransporteRepository
    {
        private readonly PersistenceContext _persistenceContext;

        public MedioTransporteRepository(PersistenceContext persistenceContext)
        {
            _persistenceContext = persistenceContext;
        }

        public async Task Add(MedioTransporte medioTransporte)
        {
           await _persistenceContext.MediosTransportes.AddAsync(medioTransporte);
        }

        public async Task<MedioTransporte> GetById(int id)
        {
            return await _persistenceContext.MediosTransportes.FindAsync(id);
        }
    }
}
