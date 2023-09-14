using System;
using TiendaOrdenadores.Componentes.Almacenadores.Guardadores;
using TiendaOrdenadores.Componentes.Almacenadores.Memorizadores;
using TiendaOrdenadores.Componentes.Procesadores;
using TiendaOrdenadores.FabricaComponentes;
using TiendaOrdenadores.FabricaComponentes.FabricaAlmacenadores.FabricaGuardadores;
using TiendaOrdenadores.FabricaComponentes.FabricaAlmacenadores.FabricaMemorizadores;
using TiendaOrdenadores.FabricaComponentes.FabricaProcesadores;
using TiendaOrdenadores.Test.UnitTestPruebasNivelesMasCompletas.FabricaOrdenadores;

namespace TiendaOrdenadores.Test.UnitTestPruebasNivelesMasCompletas
{
    [TestClass]
    public class UnitTestOrdenadoresBasicosNivelA
	{
        [TestMethod]
        public void ordenadorFabricaConBuilderBien()
        {
            FabricaOrdenadorConBuilder fabricaOrdenador = new FabricaOrdenadorConBuilder();
            IFabricaComponente fabrica = new FabricaComponente();

            IOrdenador ordenadorMaria = fabricaOrdenador.dameOrdenador(TipoOrdenador.OrdenadorMaria);
            IProcesable procesadorMaria = fabrica.dameComponente(TipoProcesador._789_XCS);
            IGuardable guardadorMaria = fabrica.dameComponente(TipoGuardador._789_XX);
            IMemorizable memorizadorMaria = fabrica.dameComponente(TipoMemorizador._879_FH);
            IOrdenador ordenadorAndres = fabricaOrdenador.dameOrdenador(TipoOrdenador.OrdenadorAndres);
            IProcesable procesadorAndres = fabrica.dameComponente(TipoProcesador._797_X3);
            IGuardable guardadorAndres = fabrica.dameComponente(TipoGuardador._789_XX_3);
            IMemorizable memorizadorAndres = fabrica.dameComponente(TipoMemorizador._879_FH_T);

            Assert.IsNotNull(ordenadorMaria);
            Assert.IsNotNull(ordenadorAndres);
            Assert.AreEqual(procesadorMaria.getCalor() + guardadorMaria.getCalor() + memorizadorMaria.getCalor(), ordenadorMaria.getCalor());
            Assert.AreEqual(procesadorMaria.getPrecio() + guardadorMaria.getPrecio() + memorizadorMaria.getPrecio(), ordenadorMaria.getPrecio());
            Assert.AreEqual(procesadorAndres.getCalor() + guardadorAndres.getCalor() + memorizadorAndres.getCalor(), ordenadorAndres.getCalor());
            Assert.AreEqual(procesadorAndres.getPrecio() + guardadorAndres.getPrecio() + memorizadorAndres.getPrecio(), ordenadorAndres.getPrecio());
        }
    }
}

