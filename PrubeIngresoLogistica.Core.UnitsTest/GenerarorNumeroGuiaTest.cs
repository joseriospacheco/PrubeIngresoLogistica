using PrubeIngresoLogistica.Core.Utils;

namespace PrubeIngresoLogistica.Core.UnitsTest
{
    public class GenerarorNumeroGuiaTest
    {
        [Fact]
        public void GenerarNumeroGuiaExitoso() {

            string pattern = "^[a-zA-Z0-9]{10}$";

            string numeroGuiaGenerado = GenerarorNumeroGuia.GenerarNumeroGuia();

            Assert.Matches(pattern, numeroGuiaGenerado);
           
        }


        [Fact]
        public void GenerarNumeroGuiaError()
        {

            string pattern = "^[^\\p{L}\\d]{0,9}$";

            string numeroGuiaGenerado = GenerarorNumeroGuia.GenerarNumeroGuia();

            Assert.DoesNotMatch(pattern, numeroGuiaGenerado);

        }
        


    }
}
