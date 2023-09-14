using TiendaOrdenadores.Componentes.Almacenadores.Guardadores;
using TiendaOrdenadores.Componentes.Almacenadores.Memorizadores;
using TiendaOrdenadores.Componentes.Procesadores;
using TiendaOrdenadores.FabricaComponentes;
using TiendaOrdenadores.FabricaComponentes.FabricaAlmacenadores.FabricaGuardadores;
using TiendaOrdenadores.FabricaComponentes.FabricaAlmacenadores.FabricaMemorizadores;
using TiendaOrdenadores.FabricaComponentes.FabricaProcesadores;

namespace TiendaOrdenadores.Test.UnitTestFabricaComponentes
{
    [TestClass]
    public class UnitTestFabricaAbstractaComponentes
    {
        private readonly IFabricaComponente fabrica;

        public UnitTestFabricaAbstractaComponentes()
        {
            fabrica = new FabricaComponente();
        }

        [TestMethod]
        public void fabricaAbstractaBien()
        {
            IProcesable procesador = fabrica.dameComponente(TipoProcesador._789_XCS);
            IMemorizable memorizador = fabrica.dameComponente(TipoMemorizador._879_FH);
            IGuardable guardador = fabrica.dameComponente(TipoGuardador._789_XX);

            Assert.IsNotNull(procesador);
            Assert.IsNotNull(memorizador);
            Assert.IsNotNull(guardador);
        }

        [TestMethod]
        public void fabricaAbstractaMal()
        {
            IProcesable procesador = fabrica.dameComponente((TipoProcesador)100);
            IMemorizable memorizador = fabrica.dameComponente((TipoMemorizador)100);
            IGuardable guardador = fabrica.dameComponente((TipoGuardador)100);

            Assert.IsNull(procesador);
            Assert.IsNull(memorizador);
            Assert.IsNull(guardador);
        }
    }
}

