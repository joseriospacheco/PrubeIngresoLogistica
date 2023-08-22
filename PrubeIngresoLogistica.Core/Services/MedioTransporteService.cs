using PrubeIngresoLogistica.Core.Entities;
using PrubeIngresoLogistica.Core.Interfaces.Repositories;
using PrubeIngresoLogistica.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrubeIngresoLogistica.Core.Services
{
    public class MedioTransporteService : IMedioTranspoteService
    {

        private readonly IUnitOfWork _unitOfWork;

        public MedioTransporteService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<MedioTransporte> Add(MedioTransporte medioTransporte)
        {
            await _unitOfWork.MedioTransporteRepository.Add(medioTransporte);
            await _unitOfWork.SaveChangesAsync();

            return medioTransporte;
        }
    }
}
