using PrubeIngresoLogistica.Core.Entities;

namespace PrubeIngresoLogistica.Core.Interfaces.Services
{
    public interface IClienteService
    {
        Task<Cliente> Add(Cliente cliente);
    }
}
