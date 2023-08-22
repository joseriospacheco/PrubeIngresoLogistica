using PrubeIngresoLogistica.Core.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrubeIngresoLogistica.Core.Entities
{
    public class Entrega : EntidadBase
    {
        public double CantidadPoducto { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaEntrega { get; set; }
        public double ValorEnvio { get; set; }

        public double ValorEnvioTotal { get; set; }

        public double Descuento { get; set; }

        public string NumeroGuia { get; set; }

        public TipoProducto TipoProducto { get; set; }

        public int TipoProductoId { get; set; }

        public Cliente Cliente { get; set; }

        public int ClienteId { get; set; }

        public LugarDestino LugarDestino { get; set; }

        public int LugarDestinoId { get; set; }

        public MedioTransporte MedioTransporte { get; set; }

        public int MedioTransporteId { get; set; }

    }

}
