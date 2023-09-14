using TiendaOrdenadores.BuilderOrdenadores;
using TiendaOrdenadores.Componentes.Almacenadores.Guardadores;
using TiendaOrdenadores.Componentes.Almacenadores.Memorizadores;
using TiendaOrdenadores.Componentes.Procesadores;
using TiendaOrdenadores.FabricaComponentes;
using TiendaOrdenadores.FabricaComponentes.FabricaAlmacenadores.FabricaGuardadores;
using TiendaOrdenadores.FabricaComponentes.FabricaAlmacenadores.FabricaMemorizadores;
using TiendaOrdenadores.FabricaComponentes.FabricaProcesadores;

namespace TiendaOrdenadores.Test.UnitTestBuilderOrdenadores
{
    [TestClass]
    public class UnitTestBuilderOrdenador
	{
		IBuilderOrdenador builder;
        IFabricaComponente fabrica;
        IProcesable procesador;
        IGuardable guardadorPrincipal;
        IMemorizable memorizador;



      [TestInitialize]
        public void inicializarTeses()
        {
            builder = new BuilderOrdenador();
            fabrica = new FabricaComponente();
            procesador = fabrica.dameComponente(TipoProcesador._789_XCS);
            guardadorPrincipal = fabrica.dameComponente(TipoGuardador._789_XX);
            memorizador = fabrica.dameComponente(TipoMemorizador._879_FH);
        }

        [TestMethod]
        public void builderOrdenadorBien()
        {
            IOrdenador ordenador = builder.dameOrdenador(TipoProcesador._789_XCS, TipoGuardador._789_XX, TipoMemorizador._879_FH);

            Assert.IsNotNull(ordenador);
            Assert.AreEqual(procesador.getCalor() + guardadorPrincipal.getCalor() + memorizador.getCalor(), ordenador.getCalor());
            Assert.AreEqual(procesador.getPrecio() + guardadorPrincipal.getPrecio() + memorizador.getPrecio(), ordenador.getPrecio());
        }

        [TestMethod]
        public void builderOrdenadorVariosGuardadoresBien()
        {
            List<TipoGuardador> tipoGuardadores = new List<TipoGuardador>
                                        {   TipoGuardador._789_XX,
                                            TipoGuardador._789_XX,
                                            TipoGuardador._789_XX };
            IOrdenador ordenador = builder.dameOrdenador(TipoProcesador._789_XCS, TipoGuardador._789_XX, tipoGuardadores, TipoMemorizador._879_FH);


            Assert.IsNotNull(ordenador);
            Assert.AreEqual(procesador.getCalor() + (4 * guardadorPrincipal.getCalor()) + memorizador.getCalor(), ordenador.getCalor());
            Assert.AreEqual(procesador.getPrecio() + (4 * guardadorPrincipal.getPrecio()) + memorizador.getPrecio(), ordenador.getPrecio());
        }

        [TestMethod]
        public void builderOrdenadorMal()
        {
            IOrdenador ordenador = builder.dameOrdenador((TipoProcesador)100, TipoGuardador._789_XX, TipoMemorizador._879_FH);
            Assert.IsNotNull(ordenador);
        }
    }
}

