using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrubeIngresoLogistica.Core.DTOs.Entrega
{
    public record EntregaResDTO(
        string NumeroGuia,
        double ValorEnvioTotal,
        ClienteResDTO Cliente
    );

}
