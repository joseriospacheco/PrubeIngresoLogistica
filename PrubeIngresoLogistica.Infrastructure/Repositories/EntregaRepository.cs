using Microsoft.EntityFrameworkCore;
using PrubeIngresoLogistica.Core.DTOs;
using PrubeIngresoLogistica.Core.Entities;
using PrubeIngresoLogistica.Core.Interfaces.Repositories;
using PrubeIngresoLogistica.Infrastructure.Data;

namespace PrubeIngresoLogistica.Infrastructure.Repositories
{
    public class EntregaRepository :  IEntregaRepository
    {

        private readonly PersistenceContext _persistenceContext;

        public EntregaRepository(PersistenceContext persistenceContext)
        {
            _persistenceContext = persistenceContext;
        }

        public async Task Add(Entrega entity)
        {
           await _persistenceContext.AddAsync(entity);
        }

        public async Task Delete(int id)
        {

            var entrega = await _persistenceContext.Entregas.FindAsync(id);
            if (entrega is not null) { 
            
                _persistenceContext.Remove(entrega);
               
            }


     
        }

        public async Task<IEnumerable<Entrega>> Filter(FiltroReqDTO filtro)
        {
            return await _persistenceContext.Entregas.Where(x => x.ClienteId == filtro.idCliente).Take(filtro.limite).ToListAsync();
        }


        public async Task<Entrega> GetById(int id)
        {                              
            return  await _persistenceContext.Entregas.FindAsync(id);
        }

        public Task<bool> GetByNumeroGuia(string numeroGuia)
        {
            return _persistenceContext.Entregas.AnyAsync(x => x.NumeroGuia.Equals(numeroGuia));
        }



        public async Task Update(Entrega entity)
        {
             _persistenceContext.Update(entity);
        }
    }
}
