using TiendaOrdenadores.Componentes.Almacenadores.Guardadores;
using TiendaOrdenadores.FabricaComponentes.FabricaAlmacenadores.FabricaGuardadores;

namespace TiendaOrdenadores.Test.UnitTestFabricaComponentes
{
    [TestClass]
    public class UnitTestFabricaGuardador
	{
        private readonly IFabricaGuardador fabrica;

        public UnitTestFabricaGuardador()
        {
            fabrica = new FabricaGuardador();
        }

        [TestMethod]
        public void fabricaProcesadorBien()
        {
            IGuardable guardador = fabrica.dameGuardador(TipoGuardador._788_FG);
            Assert.IsNotNull(guardador);
        }

        [TestMethod]
        public void fabricaProcesadorMal()
        {
            IGuardable guardador = fabrica.dameGuardador((TipoGuardador)100);
            Assert.IsNull(guardador);
        }
    }
}

