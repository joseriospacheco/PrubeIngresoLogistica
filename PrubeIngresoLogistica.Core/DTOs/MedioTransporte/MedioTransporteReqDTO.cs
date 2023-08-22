using PrubeIngresoLogistica.Core.Enumerations;

namespace PrubeIngresoLogistica.Core.DTOs.MedioTransporte
{

    public record MedioTransporteReqDTO(
        TipoMedioTransporte TipoMedioTransporte,
        string Matricula
        );

}
