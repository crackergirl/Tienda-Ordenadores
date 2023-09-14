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
    public class UnitTestOrdenadoresVariosGuardadoresNivelB
	{
        [TestMethod]
        public void ordenadorFabricaConBuilderBien()
        {
            FabricaOrdenadorConBuilder fabricaOrdenador = new FabricaOrdenadorConBuilder();
            IFabricaComponente fabrica = new FabricaComponente();

            IOrdenador ordenadorAndresCF = fabricaOrdenador.dameOrdenador(TipoOrdenador.OrdenadorAndresCF);
            IProcesable procesadorAndresCF = fabrica.dameComponente(TipoProcesador._797_X3);
            IGuardable guardadorPrimarioAndresCF = fabrica.dameComponente(TipoGuardador._788_FG);
            IGuardable guardadorSecundarioAndresCF = fabrica.dameComponente(TipoGuardador._789_XX_3);
            IMemorizable memorizadorAndresCF = fabrica.dameComponente(TipoMemorizador._879_FH_T);
            IOrdenador ordenadorTiburcioII = fabricaOrdenador.dameOrdenador(TipoOrdenador.OrdenadorTiburcioII);
            IProcesable procesadorTiburcioII = fabrica.dameComponente(TipoProcesador._789_XCS);
            IGuardable guardadorPrimarioTiburcioII = fabrica.dameComponente(TipoGuardador._789_XX);
            IGuardable guardadorSecundario1TiburcioII = fabrica.dameComponente(TipoGuardador._1789_XCS);
            IGuardable guardadorSecundario2TiburcioII = fabrica.dameComponente(TipoGuardador._788_FG);
            IMemorizable memorizadorTiburcioII = fabrica.dameComponente(TipoMemorizador._879_FH);

            Assert.IsNotNull(ordenadorAndresCF);
            Assert.IsNotNull(ordenadorTiburcioII);
            Assert.AreEqual(procesadorAndresCF.getCalor() + guardadorPrimarioAndresCF.getCalor() + guardadorSecundarioAndresCF.getCalor() + memorizadorAndresCF.getCalor(), ordenadorAndresCF.getCalor());
            Assert.AreEqual(procesadorAndresCF.getPrecio() + guardadorPrimarioAndresCF.getPrecio() + guardadorSecundarioAndresCF.getPrecio() + memorizadorAndresCF.getPrecio(), ordenadorAndresCF.getPrecio());
            Assert.AreEqual(procesadorTiburcioII.getCalor() + guardadorPrimarioTiburcioII.getCalor() + guardadorSecundario1TiburcioII.getCalor() + guardadorSecundario2TiburcioII.getCalor() + memorizadorTiburcioII.getCalor(), ordenadorTiburcioII.getCalor());
            Assert.AreEqual(procesadorTiburcioII.getPrecio() + guardadorPrimarioTiburcioII.getPrecio() + guardadorSecundario1TiburcioII.getPrecio() + guardadorSecundario2TiburcioII.getPrecio() + memorizadorTiburcioII.getPrecio(), ordenadorTiburcioII.getPrecio());
        }
    }
}

