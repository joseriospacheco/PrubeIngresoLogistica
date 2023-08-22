using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrubeIngresoLogistica.Core.DTOs.Cliente
{

    public record ClienteReqDTO(

        string Nombre,
        string Direccion,
        string Telefono,
        string Email

    );
}
