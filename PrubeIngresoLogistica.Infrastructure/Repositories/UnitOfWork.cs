using PrubeIngresoLogistica.Core.Entities;
using PrubeIngresoLogistica.Core.Interfaces.Repositories;
using PrubeIngresoLogistica.Infrastructure.Data;

namespace PrubeIngresoLogistica.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork,IDisposable
    {
        private readonly PersistenceContext _persistenceContext;

        public IClienteRepository ClienteRepository { get; }
        public IEntregaRepository EntregaRepository { get; }
        public ILugarDestinoRepository LugarDestinoRepository { get; }
        public IMedioTransporteRepository MedioTransporteRepository { get; }
        public UnitOfWork(PersistenceContext persistenceContext,
            IClienteRepository clienteRepository,
            IEntregaRepository entregaRepository,
            ILugarDestinoRepository lugarDestinoRepository,
            IMedioTransporteRepository medioTransporteRepository)
        {
            _persistenceContext = persistenceContext;
            ClienteRepository = clienteRepository;
            EntregaRepository = entregaRepository;
            LugarDestinoRepository = lugarDestinoRepository;
            MedioTransporteRepository = medioTransporteRepository;
        }


        public async Task<int> SaveChangesAsync()
        {            
            return  await _persistenceContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _persistenceContext.Dispose();
        }
    }
}
