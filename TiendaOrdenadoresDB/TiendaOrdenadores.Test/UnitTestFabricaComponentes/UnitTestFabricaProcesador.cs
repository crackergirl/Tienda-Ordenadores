using TiendaOrdenadores.Componentes.Procesadores;
using TiendaOrdenadores.FabricaComponentes.FabricaProcesadores;

namespace TiendaOrdenadores.Test.UnitTestFabricaComponentes
{
    [TestClass]
    public class UnitTestFabricaProcesador
	{
        private readonly IFabricaProcesador fabrica;

        public UnitTestFabricaProcesador()
        {
            fabrica = new FabricaProcesador();
        }

        [TestMethod]
        public void fabricaProcesadorBien()
        {
            IProcesable procesador = fabrica.dameProcesador(TipoProcesador._789_XCS);
            Assert.IsNotNull(procesador);
        }

        [TestMethod]
        public void fabricaProcesadorMal()
        {
            IProcesable procesador = fabrica.dameProcesador((TipoProcesador)100);
            Assert.IsNull(procesador);
        }

    }
}

