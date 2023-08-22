using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrubeIngresoLogistica.Core.DTOs
{
    public record FiltroReqDTO(
    
        int idCliente,
        int limite
        
    );
}
