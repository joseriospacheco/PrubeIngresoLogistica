using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrubeIngresoLogistica.Core.Entities
{
    public class Cliente: EntidadBase
    {
        public string Nombre { get; set; }
        public string Direccion { get; set; }
       public string Telefono { get; set; }
        public string Email { get; set; }

    }
}
