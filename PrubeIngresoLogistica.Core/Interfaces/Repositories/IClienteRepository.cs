using PrubeIngresoLogistica.Core.Entities;

namespace PrubeIngresoLogistica.Core.Interfaces.Repositories
{
    public interface IClienteRepository
    {
        Task Add(Cliente cliente);

        Task<Cliente> GetById(int id);
    }
}
