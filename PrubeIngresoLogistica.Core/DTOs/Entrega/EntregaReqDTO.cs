using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrubeIngresoLogistica.Core.DTOs.Entrega
{

    public record EntregaReqDTO(
        int TipoProductoId,
        double CantidadPoducto,
        int MedioTransporteId,
        int ClienteId,
        int LugarDestinoId,
        double ValorEnvio,
        DateTime FechaEntrega
        );
}
