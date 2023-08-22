using PrubeIngresoLogistica.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrubeIngresoLogistica.Core.Interfaces.Services
{
    public interface IMedioTranspoteService
    {
        Task<MedioTransporte> Add(MedioTransporte medioTransporte);
    }
}
