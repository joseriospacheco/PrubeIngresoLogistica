using PrubeIngresoLogistica.Core.Entities;
using PrubeIngresoLogistica.Core.Interfaces.Repositories;
using PrubeIngresoLogistica.Core.Interfaces.Services;

namespace PrubeIngresoLogistica.Core.Services
{
    public class ClienteService : IClienteService
    {

        private readonly IUnitOfWork _unitOfWork;

        public ClienteService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Cliente> Add(Cliente entity)
        {
           await _unitOfWork.ClienteRepository.Add(entity);
           await _unitOfWork.SaveChangesAsync();

            return entity;
        }




    }
}
