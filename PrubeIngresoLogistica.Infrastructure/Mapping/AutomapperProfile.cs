using AutoMapper;
using PrubeIngresoLogistica.Core.DTOs.Cliente;
using PrubeIngresoLogistica.Core.DTOs.Entrega;
using PrubeIngresoLogistica.Core.DTOs.MedioTransporte;
using PrubeIngresoLogistica.Core.Entities;

namespace PrubeIngresoLogistica.Infrastructure.Mapping
{
    public class AutomapperProfile: Profile
    {
        public AutomapperProfile() {

            CreateMap<ClienteReqDTO, Cliente>();
            CreateMap<EntregaReqDTO, Entrega>();
            CreateMap<EditarEntregaReqDTO, Entrega>();
            CreateMap<Entrega, EntregaResDTO>();
            CreateMap<Cliente, ClienteResDTO>();
            CreateMap<MedioTransporteReqDTO, MedioTransporte>();

        }
    }
}
