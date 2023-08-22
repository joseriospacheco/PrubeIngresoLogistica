using PrubeIngresoLogistica.Core.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrubeIngresoLogistica.Core.Entities
{
    public class LugarDestino: EntidadBase
    {
        public string Nombre  { get; set; }
        public TipoLugarDestino Tipo { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }


    }
}
