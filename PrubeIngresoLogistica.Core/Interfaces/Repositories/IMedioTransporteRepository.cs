using PrubeIngresoLogistica.Core.Entities;

namespace PrubeIngresoLogistica.Core.Interfaces.Repositories
{
    public interface IMedioTransporteRepository
    {
        Task Add(MedioTransporte medioTransporte);

        Task<MedioTransporte> GetById(int id);
    }
}
