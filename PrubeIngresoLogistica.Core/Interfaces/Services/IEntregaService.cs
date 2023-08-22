using PrubeIngresoLogistica.Core.DTOs;
using PrubeIngresoLogistica.Core.Entities;
using PrubeIngresoLogistica.Core.Enumerations;

namespace PrubeIngresoLogistica.Core.Interfaces.Services
{
    public interface IEntregaService {

        Task<Entrega> GetById(int id);
        Task<Entrega> Add(Entrega entity);
        Task Update(Entrega entity);
        Task<bool> Delete(int id);
        Task<IEnumerable<Entrega>> Filter(FiltroReqDTO filtro);
        double CalcularDescuento(double cantidad, TipoLugarDestino tipoLugarDestino, double valorEnvio);
    }
}
