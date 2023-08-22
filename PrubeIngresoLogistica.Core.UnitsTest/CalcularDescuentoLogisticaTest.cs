using PrubeIngresoLogistica.Core.Enumerations;
using PrubeIngresoLogistica.Core.Interfaces.Services;
using PrubeIngresoLogistica.Core.Services;

namespace PrubeIngresoLogistica.Core.UnitsTest
{
    public class CalcularDescuentoLogisticaTest
    {
        [Fact]
        public void CalcularDescuentoLogisticaTerrestreExito()
        {

            double valorEnvio = 100_000;
            double cantidad = 11;
            double valorEsperado = 3_000;

            IEntregaService entregaService = new EntregaService(null);

            double valorCalculado = entregaService.CalcularDescuento(cantidad,TipoLugarDestino.PUERTO,valorEnvio);

            Assert.Equal(valorEsperado, valorCalculado);

        }

        [Fact]
        public void CalcularDescuentoLogisticaTerrestreError()
        {

            double valorEnvio = 100_000;
            double cantidad = 1;
            double valorEsperado = 3_000;

            IEntregaService entregaService = new EntregaService(null);

            double valorCalculado = entregaService.CalcularDescuento(cantidad, TipoLugarDestino.BODEGA, valorEnvio);

            Assert.NotEqual(valorEsperado, valorCalculado);

        }

        [Fact]
        public void CalcularDescuentoLogisticaMaritimaExito()
        {

            double valorEnvio = 100_000;
            double cantidad = 11;
            double valorEsperado = 5_000;

            IEntregaService entregaService = new EntregaService(null);

            double valorCalculado = entregaService.CalcularDescuento(cantidad, TipoLugarDestino.BODEGA, valorEnvio);

            Assert.Equal(valorEsperado, valorCalculado);

        }

        [Fact]
        public void CalcularDescuentoLogisticaMaritimaError()
        {

            double valorEnvio = 100_000;
            double cantidad = 1;
            double valorEsperado = 5_000;

            IEntregaService entregaService = new EntregaService(null);

            double valorCalculado = entregaService.CalcularDescuento(cantidad, TipoLugarDestino.PUERTO, valorEnvio);

            Assert.NotEqual(valorEsperado, valorCalculado);

        }
    }
}