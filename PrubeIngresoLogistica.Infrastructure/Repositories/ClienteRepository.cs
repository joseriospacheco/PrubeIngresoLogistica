using PrubeIngresoLogistica.Core.Entities;
using PrubeIngresoLogistica.Core.Interfaces.Repositories;
using PrubeIngresoLogistica.Infrastructure.Data;

namespace PrubeIngresoLogistica.Infrastructure.Repositories
{
    public class ClienteRepository : IClienteRepository
    {

        private readonly PersistenceContext _persistenceContext;

        public ClienteRepository(PersistenceContext persistenceContext)
        {
            _persistenceContext = persistenceContext;
        }

        public async Task Add(Cliente entity)
        {
           await _persistenceContext.AddAsync(entity);
           
        }

        public async Task<Cliente> GetById(int id)
        {
           return await _persistenceContext.Clientes.FindAsync(id);
        }


    }
}
