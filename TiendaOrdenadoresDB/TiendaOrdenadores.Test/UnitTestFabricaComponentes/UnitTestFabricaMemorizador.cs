using TiendaOrdenadores.Componentes.Almacenadores.Memorizadores;
using TiendaOrdenadores.FabricaComponentes.FabricaAlmacenadores.FabricaMemorizadores;

namespace TiendaOrdenadores.Test.UnitTestFabricaComponentes
{
    [TestClass]
    public class UnitTestFabricaMemorizador
	{
        private readonly IFabricaMemorizador fabrica;

        public UnitTestFabricaMemorizador()
        {
            fabrica = new FabricaMemorizador();
        }

        [TestMethod]
        public void fabricaProcesadorBien()
        {
            IMemorizable memorizador = fabrica.dameMemorizador(TipoMemorizador._879_FH);
            Assert.IsNotNull(memorizador);
        }

        [TestMethod]
        public void fabricaProcesadorMal()
        {
            IMemorizable memorizador = fabrica.dameMemorizador((TipoMemorizador)100);
            Assert.IsNull(memorizador);
        }
    }
}

