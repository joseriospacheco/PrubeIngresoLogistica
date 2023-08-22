using PrubeIngresoLogistica.Core.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrubeIngresoLogistica.Core.Entities
{
    public class MedioTransporte: EntidadBase
    {
        public TipoMedioTransporte TipoMedioTransporte { get; set; }
        public string Matricula { get; set; }
    }
}
